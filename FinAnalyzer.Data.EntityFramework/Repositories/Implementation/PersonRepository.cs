using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Person?> GetByLogin(string login)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<PaginationResponse<Person>> GetAllAsync(PaginationRequest pagination)
    {
        var query = _context.Persons.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.SearchText))
        {
            query = query.Where(p => p.Login.Contains(pagination.SearchText) ||
                (p.Lastname != null && p.Lastname.Contains(pagination.SearchText)) ||
                (p.Firstname != null && p.Firstname.Contains(pagination.SearchText)));
        }

        var totalCount = await query.CountAsync();

        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<Person>
        {
            TotalCount = totalCount,
            Items = await query.ToListAsync()
        };
    }

    public async Task<bool> UpdateAsync(Person person)
    {
        var updatedPerson = await GetByIdAsync(person.Id);

        if (updatedPerson is null) return false;

        updatedPerson.Login = person.Login;
        updatedPerson.Firstname = person.Login;
        updatedPerson.Middlename = person.Middlename;
        updatedPerson.Lastname = person.Lastname;

        await _context.SaveChangesAsync();
        return true;
    }
}