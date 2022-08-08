using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Auth;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface IAuthService
{
    Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request);

    Task<OperationResult<int>> RegistrationAsync(RegistrationRequest request);
}

