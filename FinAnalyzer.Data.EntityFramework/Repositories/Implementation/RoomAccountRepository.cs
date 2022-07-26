﻿using FinAnalyzer.Common;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Implementation;

public class RoomAccountRepository : BaseRepository<RoomAccount>, IRoomAccountRepository
{
    public RoomAccountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PaginationResponse<RoomAccount>> GetAllAsync(PaginationRequest pagination)
    {
        var query = _context.RoomAccounts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.SearchText))
        {
            query = query.Where(p => p.Name.Contains(pagination.SearchText));
        }

        var totalCount = await query.CountAsync();

        query = query.Skip(pagination.Skip).Take(pagination.Take);

        return new PaginationResponse<RoomAccount>
        {
            TotalCount = totalCount,
            Items = await query.ToListAsync()
        };
    }

    public async Task<bool> UpdateAsync(RoomAccount account)
    {
        var updatedAccount = await GetByIdAsync(account.Id);

        if (updatedAccount is null) return false;

        updatedAccount.Name = account.Name;

        await _context.SaveChangesAsync();
        return true;
    }
}

