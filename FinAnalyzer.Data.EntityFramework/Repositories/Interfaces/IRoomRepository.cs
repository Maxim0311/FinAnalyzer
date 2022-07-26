using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<PaginationResponse<Room>> GetAllAsync(PaginationRequest pagination);
    Task<PaginationResponse<Room>> GetByPersonIdAsync(int personId, PaginationRequest pagination);
    Task<Room?> GetByNameAsync(string name);
    Task<int> CreateAsync(Room room);
    Task<bool> UpdateAsync(Room room);
    Task<bool> DeleteAsync(int id);
}