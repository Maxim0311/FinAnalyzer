using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Common.Auth;
using FinAnalyzer.Core.Dto.Auth;
using FinAnalyzer.Core.Dto.Person;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StafferyInternal.StafferyInternal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BC = BCrypt.Net.BCrypt;

namespace FinAnalyzer.Core.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IPersonRepository _personRepository;
    private readonly IGlobalRoleRepository _globalRoleRepository;
    private readonly IPersonRoomRepository _personRoomRepository;
    private readonly IMapper _mapper;
    private readonly AuthOptions _authOptions;

    public AuthService(
        IPersonRepository personRepository,
        IGlobalRoleRepository globalRoleRepository,
        IPersonRoomRepository personRoomRepository,
        IMapper mapper,
        IOptions<AuthOptions> authOptions)
    {
        _personRepository = personRepository;
        _globalRoleRepository = globalRoleRepository;
        _personRoomRepository = personRoomRepository;
        _mapper = mapper;
        _authOptions = authOptions.Value;
    }

    public async Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request)
    {
        var person = await _personRepository.GetByLogin(request.Login);

        if (person is null)
            return OperationResult<AuthResponse>.Fail(
                OperationCode.Error,
                $"Пользователь с логином {request.Login} не найден");

        if (BC.Verify(request.Password, person.Password))
        {
            var token = await GenerateJwtTokenAsync(person);

            var response = new AuthResponse
            {
                Person = _mapper.Map<PersonResponse>(person),
                Token = token
            };

            return new OperationResult<AuthResponse>(response);
        }

        return OperationResult<AuthResponse>.Fail(OperationCode.Error, "Неверный пароль");
    }


    public async Task<OperationResult<int>> RegistrationAsync(RegistrationRequest request)
    {
        if (await _personRepository.GetByLogin(request.Login) is not null)
            return OperationResult<int>.Fail(
                OperationCode.AlreadyExists,
                $"Пользователь с логином {request.Login} уже существует");

        var person = _mapper.Map<Person>(request);

        person.Password = BC.HashPassword(request.Password);
        person.GlobalRoleId = 2;

        var createdId = await _personRepository.CreateAsync(person);

        return new OperationResult<int>(createdId);
    }

    public async Task<bool> CheckRoomPermissionAsync(string jwt, int roomId, int roleId)
    {
        var personId = GetPersonId(jwt);

        var roomCredentions = await _personRoomRepository.GetRoomCredentialsAsync(personId);

        var currentRoomCredention = roomCredentions.FirstOrDefault(r => r.RoomId == roomId);

        if (currentRoomCredention is null) return false;

        return currentRoomCredention.RoleId <= roleId;
    }

    public bool IsPersonId(string jwt, int personId)
    {
        return GetPersonId(jwt) == personId;
    }

    private int GetPersonId(string jwt)
    {
        var token = GetJwtToken(jwt);

        var personId = Convert.ToInt32(
                token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);

        return personId;
    }

    private async Task<string> GenerateJwtTokenAsync(Person person)
    {
        var securityKey = _authOptions.GetSymmetricSecurityKey();

        var globalRole = await _globalRoleRepository.GetByIdAsync(person.GlobalRoleId);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Sid, person.Id.ToString()),
            new Claim(ClaimTypes.Role, globalRole!.Title)
        };

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_authOptions.Issuer,
            _authOptions.Audience,
            claims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddDays(_authOptions.TokenLifeTime));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GetJwtToken(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();

        jwt = jwt.Replace("Bearer ", "");
        var token = (JwtSecurityToken)handler.ReadToken(jwt);

        return token;
    }
}
