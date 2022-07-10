using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> IsExistAsync(int id);

        Task<TEntity?> GetByIdAsync(int id);
    }
}
