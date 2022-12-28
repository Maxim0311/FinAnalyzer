using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<PaginationResponse<Account>> GetAllAsync(PaginationRequest pagination)
    {
        var query = _context.Accounts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.SearchText))
        {
            query = query.Where(p => p.Name.Contains(pagination.SearchText));
        }

        var totalCount = await query.CountAsync();

        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<Account>
        {
            TotalCount = totalCount,
            Items = await query.ToListAsync()
        };
    }

    public async Task<IEnumerable<Account>> GetAllByRoom(int roomId)
    {
        return await _context.Accounts
            .Include(x => x.AccountType)
            .Include(x => x.Person)
            .Where(x => x.RoomId == roomId).ToListAsync();
    }

    public async Task<IEnumerable<Account>> GetByPerson(int roomId, int personId)
    {
        return await _context.Accounts
            .Include(x => x.AccountType)
            .Include(x => x.Person)
            .Where(x => x.RoomId == roomId && x.PersonId == personId).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Account account)
    {
        var updatedAccount = await GetByIdAsync(account.Id);

        if (updatedAccount is null) return false;

        updatedAccount.Name = account.Name;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DepositMoney(int accountId, decimal amount)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account != null)
        {
            account.Balance += amount;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<bool> WithdrowMoney(int accountId, decimal amount)
    {
        var account = await _context.Accounts.FindAsync(accountId);

        if (account == null || account.Balance < amount)
            return false;

        account.Balance -= amount;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> TransactMoney(int senderId, int destinationId, decimal amount)
    {
        var sender = await _context.Accounts.FindAsync(senderId);
        var destination = await _context.Accounts.FindAsync(destinationId);

        if (sender == null || destination == null || sender.Balance < amount)
            return false;

        sender.Balance -= amount;
        destination.Balance += amount;
        await _context.SaveChangesAsync();
        return true;
    }
}
