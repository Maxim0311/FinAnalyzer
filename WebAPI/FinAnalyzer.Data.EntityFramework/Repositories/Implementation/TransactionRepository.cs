using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<int> CreateAsync(Transaction entity)
    {
        _context.Transactions.Add(entity);
        var createdId = await _context.SaveChangesAsync();
        return createdId;
    }

    public async Task<IEnumerable<Transaction>> GetByRoomIdAsync(int roomId)
    {
        return await _context.Transactions
            .Include(x => x.Category)
            .Include(x => x.Sender)
            .Include(x => x.Destination)
            .Where(x => x.RoomId == roomId)
            .ToListAsync();
    }
}

