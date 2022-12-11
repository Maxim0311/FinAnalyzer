using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IPersonRepository : IBaseRepository<Person>
{
    Task<Person?> GetByLogin(string login);
    Task<bool> UpdateAsync(Person person);
    Task<PaginationResponse<Person>> GetAllAsync(PaginationRequest pagination);
}

