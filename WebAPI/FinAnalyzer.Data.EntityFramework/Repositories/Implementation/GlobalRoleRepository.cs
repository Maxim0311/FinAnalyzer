using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class GlobalRoleRepository : BaseRepository<GlobalRole>, IGlobalRoleRepository
{
    public GlobalRoleRepository(AppDbContext context) : base(context)
    {
    }
}
