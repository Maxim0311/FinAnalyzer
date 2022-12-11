using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Auth;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface IAuthService
{
    Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request);

    Task<OperationResult<int>> RegistrationAsync(RegistrationRequest request);

    /// <summary>
    /// Проверяет, имеет ли пользователь определённую роль в комнате
    /// </summary>
    /// <param name="jwt">Токен аутентификации пользователя</param>
    /// <param name="roomId">id комнаты</param>
    /// <param name="roleId">id роли</param>
    /// <returns></returns>
    Task<bool> CheckRoomPermissionAsync(string jwt, int roomId, int roleId);

    /// <summary>
    /// Проверяет, содержит ли токен необходимый id пользователя
    /// </summary>
    /// <param name="jwt">Токен аутентификации пользователя</param>
    /// <param name="personId">id пользователя</param>
    /// <returns></returns>
    bool IsPersonId(string jwt, int personId);
}

