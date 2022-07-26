using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IRoomAccountRepository : IBaseRepository<RoomAccount>
{
    Task<PaginationResponse<RoomAccount>> GetAllAsync(PaginationRequest pagination);
    Task<bool> UpdateAsync(RoomAccount account);
}

