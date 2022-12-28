using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class AccountTypeRepository : BaseRepository<AccountType>, IAccountTypeRepository
{
    public AccountTypeRepository(AppDbContext context) : base(context)
    {
    }
}

