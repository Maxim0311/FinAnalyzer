using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<bool> IsExistAsync(int id);

    Task<TEntity?> GetByIdAsync(int id);

    Task<int> CreateAsync(TEntity entity);

    Task<bool> DeleteAsync(int id);
}

