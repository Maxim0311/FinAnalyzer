using AutoMapper;
using FinAnalyzer.Common;
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
    private readonly IMapper _mapper;
    private readonly AuthOptions _authOptions;

    public AuthService(
        IPersonRepository personRepository,
        IGlobalRoleRepository globalRoleRepository,
        IMapper mapper,
        IOptions<AuthOptions> authOptions) 
    {
        _personRepository = personRepository;
        _globalRoleRepository = globalRoleRepository;
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
}
