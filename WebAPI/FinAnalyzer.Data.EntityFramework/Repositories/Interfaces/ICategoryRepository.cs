using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<IEnumerable<Category>> GetByRoomIdAsync(int roomId);

    Task<bool> UpdateAsync(Category category);
}
