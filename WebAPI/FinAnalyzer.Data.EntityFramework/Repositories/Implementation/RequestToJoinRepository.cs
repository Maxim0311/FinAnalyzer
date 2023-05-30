using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class RequestToJoinRepository : IRequestToJoinRepository
{
    private readonly AppDbContext _context;

    public RequestToJoinRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task Apply(int roomId, int personId)
    {
        var request = new RequestToJoin
        {
            CreateDate = DateTime.UtcNow,
            PersonId = personId,
            RoomId = roomId,
            Status = RequestToJoinStatus.New
        };

        await _context.RequestsToJoin.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Accept(int requestId)
    {
        var request = await Get(requestId);
        var personRooms = new PersonRoom
        {
            PersonId = request.PersonId,
            RoomId = request.RoomId,
            RoomRoleId = 3
        };
        await _context.PersonRooms.AddAsync(personRooms);
        request.Status = RequestToJoinStatus.Accepted;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Reject(int requestId)
    {
        var request = await Get(requestId);
        request.Status = RequestToJoinStatus.Rejected;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<RequestToJoin>> GetAllAsync(int roomId)
    {
        return await _context.RequestsToJoin.Include(x => x.Person).Where(x => x.RoomId == roomId).ToListAsync();
    }

    private async Task<RequestToJoin> Get(int requestId)
    {
        return await _context.RequestsToJoin.FindAsync(requestId);
    }
}
