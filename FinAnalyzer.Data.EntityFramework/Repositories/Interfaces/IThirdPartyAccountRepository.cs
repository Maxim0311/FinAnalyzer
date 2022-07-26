using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IThirdPartyAccountRepository : IBaseRepository<ThirdPartyAccount>
{
    Task<PaginationResponse<ThirdPartyAccount>> GetAllAsync(PaginationRequest pagination);
    Task<bool> UpdateAsync(ThirdPartyAccount account);
}

