using FinAnalyzer.Common.Auth;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IPersonRoomRepository
{
    /// <summary>
    /// Получения коллекции объектов содержащих id комнаты и соответсвующей 
    /// роли в этой комнате у определённого пользователя
    /// </summary>
    /// <param name="personId">id пользователя</param>
    /// <returns></returns>
    Task<IEnumerable<RoomCredentials>> GetRoomCredentialsAsync(int personId);
}

