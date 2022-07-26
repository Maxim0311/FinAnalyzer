using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IPersonAccountRepository : IBaseRepository<PersonAccount>
{
    Task<PaginationResponse<PersonAccount>> GetAllAsync(PaginationRequest pagination);
    Task<bool> UpdateAsync(PersonAccount account);
}

