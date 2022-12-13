using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetByRoomIdAsync(int roomId)
    {
        return await _context.Categories.Where(c => c.RoomId == roomId).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var updatedCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
        if (updatedCategory == null)
            return false;

        updatedCategory.Name = category.Name;
        updatedCategory.Description = category.Description;
        updatedCategory.IconAuthor = category.IconAuthor;
        updatedCategory.IconName = category.IconName;
        updatedCategory.Color = category.Color;
        updatedCategory.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }
}

