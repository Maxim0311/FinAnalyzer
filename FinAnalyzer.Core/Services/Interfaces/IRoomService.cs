﻿using FinAnalyzer.Common;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface IRoomService
{
    Task<OperationResult<int>> CreateAsync(RoomCreateRequest request);

    Task<OperationResult> UpdateAsync(RoomUpdateRequest request);

    Task<OperationResult> DeleteAsync(int id);

    Task<OperationResult<PaginationResponse<RoomResponse>>> GetAllAsync
        (PaginationRequest pagination);
    
    Task<OperationResult<PaginationResponse<RoomResponse>>> GetByPersonIdAsync
        (int personId, PaginationRequest pagination);

    Task<OperationResult<RoomResponse>> GetByIdAsync(int id);
}

