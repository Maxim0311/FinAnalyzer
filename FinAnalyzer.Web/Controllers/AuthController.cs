using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Auth;
using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<OperationResult<AuthResponse>>> Authenticate(AuthRequest request)
    {
        var response = await _authService.AuthenticateAsync(request);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }
    
    [HttpPost("registration")]
    public async Task<ActionResult<OperationResult<AuthResponse>>> Registration(RegistrationRequest request)
    {
        var response = await _authService.RegistrationAsync(request);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }
}

