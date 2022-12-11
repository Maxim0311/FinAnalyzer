using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<PaginationResponse<Account>> GetAllAsync(PaginationRequest pagination);
    Task<bool> UpdateAsync(Account account);
}

