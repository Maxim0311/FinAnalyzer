using FinAnalyzer.Common.Auth;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class PersonRoomRepository : IPersonRoomRepository
{
    private readonly AppDbContext _context;

    public PersonRoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoomCredentials>> GetRoomCredentialsAsync(int personId)
    {
        return await _context.PersonRooms
            .Where(r => r.PersonId == personId)
            .Select(r => new RoomCredentials { RoomId = r.RoomId, RoleId = r.RoomRoleId })
            .ToListAsync();
    }
}

