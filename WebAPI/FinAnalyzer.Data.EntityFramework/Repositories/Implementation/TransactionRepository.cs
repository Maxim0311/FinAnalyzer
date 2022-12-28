using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;

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
}

