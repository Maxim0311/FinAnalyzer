﻿using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using StafferyInternal.StafferyInternal.Common;

namespace FinAnalyzer.Core.Services.Implementation;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public RoomService(
        IRoomRepository roomRepository, 
        IMapper mapper, 
        IPersonRepository personRepository)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _personRepository = personRepository;
    }

    public async Task<OperationResult<int>> CreateAsync(RoomCreateRequest request)
    {
        if (await _roomRepository.GetByNameAsync(request.Name) is not null)
            return OperationResult<int>.Fail(
                OperationCode.AlreadyExists, 
                "Комната с таким именем уже существует");

        var room = _mapper.Map<Room>(request);

        var person = await _personRepository.GetByIdAsync(request.PersonId);

        if (person is null)
            return OperationResult<int>.Fail(
                OperationCode.EntityWasNotFound,
                "Пользователь не найден");

        var personRoom = new PersonRoom
        {
            Room = room,
            Person = person,
            RoomRoleId = 1
        };

        room.PersonRooms.Add(personRoom);

        var startRoomAccount = new RoomAccount
        {
            Name = Consts.StartRoomAccountName,
            Balance = 0
        };

        var startPersonAccount = new PersonAccount
        {
            Person = person,
            Name = Consts.StartPersonAccountName,
            Balance = 0
        };

        room.Accounts.Add(startPersonAccount);
        room.Accounts.Add(startRoomAccount);

        var createdId = await _roomRepository.CreateAsync(room);

        return new OperationResult<int>(createdId);
    }

    public async Task<OperationResult> DeleteAsync(int id)
    {
        var result = await _roomRepository.DeleteAsync(id);

        if (result) return OperationResult.OK;

        return OperationResult.Fail(OperationCode.EntityWasNotFound, "Комната не найдена");
    }

    public async Task<OperationResult<PaginationResponse<RoomResponse>>> GetAllAsync(PaginationRequest pagination)
    {
        var rooms = await _roomRepository.GetAllAsync(pagination);

        if (rooms.Items.Count() == 0)
            return OperationResult<PaginationResponse<RoomResponse>>.Fail(
                OperationCode.EntityWasNotFound,
                "Не найдено ни одной комнаты");

        var response = _mapper.Map<PaginationResponse<RoomResponse>>(rooms);

        return new OperationResult<PaginationResponse<RoomResponse>>(response);
    }

    public async Task<OperationResult<RoomResponse>> GetByIdAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);

        if (room is null)
            return OperationResult<RoomResponse>.Fail(
                OperationCode.EntityWasNotFound,
                "Комната не найдена");

        var responseDto = _mapper.Map<RoomResponse>(room);

        return new OperationResult<RoomResponse>(responseDto);
    }

    public async Task<OperationResult<PaginationResponse<RoomResponse>>> GetByPersonIdAsync(int personId, PaginationRequest pagination)
    {
        var rooms = await _roomRepository.GetByPersonIdAsync(personId, pagination);

        if (rooms.Items.Count() == 0)
            return OperationResult<PaginationResponse<RoomResponse>>.Fail(
                OperationCode.EntityWasNotFound,
                "Не найдено ни одной комнаты");

        var response = _mapper.Map<PaginationResponse<RoomResponse>>(rooms);

        return new OperationResult<PaginationResponse<RoomResponse>>(response);
    }

    public async Task<OperationResult> UpdateAsync(RoomUpdateRequest request)
    {
        if (await _roomRepository.GetByNameAsync(request.Name) is not null)
            return OperationResult<int>.Fail(
                OperationCode.AlreadyExists,
                "Комната с таким именем уже существует");

        var updatedRoom = _mapper.Map<Room>(request);

        if (await _roomRepository.UpdateAsync(updatedRoom))
            return OperationResult.OK;

        return OperationResult<int>.Fail(
                OperationCode.EntityWasNotFound,
                "Комната не найдена");
    }
}

