using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<int> CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is null) return false;

        entity.DeleteDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<PaginationResponse<TEntity>> GetAllAsync(PaginationRequest pagination)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        var totalCount = await query.CountAsync();
        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<TEntity>
        {
            Items = await query.ToListAsync(),
            TotalCount = totalCount,
        };
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<bool> IsExistAsync(int id)
    {
        return await _context.Set<TEntity>().AnyAsync(entity => entity.Id == id);
    }
}

