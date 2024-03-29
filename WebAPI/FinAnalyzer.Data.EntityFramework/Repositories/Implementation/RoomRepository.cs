﻿using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<int> CreateAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room.Id;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        var room = await _context.Rooms.Include(r => r.PersonRooms)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (room is null) return false;

        room.DeleteDate = DateTime.UtcNow;

        foreach (var pr in room.PersonRooms)
        {
            pr.DeleteDate = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public override async Task<PaginationResponse<Room>> GetAllAsync(PaginationRequest pagination)
    {
        var query = _context.Rooms.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.SearchText))
        {
            query = query.Where(r =>
                r.Name.ToLower().Contains(pagination.SearchText.ToLower()) ||
                r.Description.ToLower().Contains(pagination.SearchText.ToLower()));
        }

        var totalCount = await query.CountAsync();
        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<Room>
        {
            Items = await query.ToListAsync(),
            TotalCount = totalCount,
        };
    }

    public async Task<Room?> GetByNameAsync(string name)
    {
        return await _context.Rooms.FirstOrDefaultAsync(r => r.Name == name);
    }

    public async Task<PaginationResponse<Room>> GetByPersonIdAsync(int personId, PaginationRequest pagination)
    {
        var query = _context.Rooms.Where(r => r.PersonRooms.Any(p => p.PersonId == personId));

        if (!string.IsNullOrWhiteSpace(pagination.SearchText))
        {
            query = query.Where(r =>
                r.Name.Contains(pagination.SearchText) ||
                r.Description.Contains(pagination.SearchText));
        }

        var totalCount = await query.CountAsync();
        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<Room>
        {
            Items = await query.ToListAsync(),
            TotalCount = totalCount,
        };
    }

    public async Task<bool> UpdateAsync(Room room)
    {
        var updatedRoom = await GetByIdAsync(room.Id);

        if (updatedRoom is null) return false;

        updatedRoom.Name = room.Name;
        updatedRoom.Description = room.Description;
        updatedRoom.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}

