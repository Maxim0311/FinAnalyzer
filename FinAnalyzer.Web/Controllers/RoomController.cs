using FinAnalyzer.Common;
using FinAnalyzer.Core;
using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StafferyInternal.StafferyInternal.Common;

namespace FinAnalyzer.Web.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    /// <summary>
    /// Получение коллекции всех комнат
    /// </summary>
    /// <param name="searchText">Поиск по названию и описанию</param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<OperationResult<PaginationResponse<RoomResponse>>>> 
        GetAll(string? searchText, int skip = 0, int take = 20)
    {
        var pagination = new PaginationRequest
        {
            SearchText = searchText,
            Skip = skip,
            Take = take
        };

        var result = await _roomService.GetAllAsync(pagination);

        if (result.Success)
            return Ok(result);

        if (result.ErrorCode == OperationCode.EntityWasNotFound)
            return NotFound(result);

        return BadRequest(result);
    }

    /// <summary>
    /// Получение комнаты по id
    /// </summary>
    /// <param name="id">id комнаты</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OperationResult<RoomResponse>>> 
        GetById(int id)
    {
        

        var result = await _roomService.GetByIdAsync(id);

        if (result.Success)
            return Ok(result);

        if (result.ErrorCode == OperationCode.EntityWasNotFound)
            return NotFound(result);

        return BadRequest(result);
    }
    
    /// <summary>
    /// Получения коллекции комнат, в которых состоит пользователь
    /// </summary>
    /// <param name="id">id пользователя</param>
    /// <param name="searchText">Поиск по названию и описанию</param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    [HttpGet("get-by-personid/{id}")]
    public async Task<ActionResult<OperationResult<PaginationResponse<RoomResponse>>>>
        GetByPersonId(int id, string? searchText, int skip = 0, int take = 20)
    {
        var pagination = new PaginationRequest
        {
            SearchText = searchText,
            Skip = skip,
            Take = take
        };

        var result = await _roomService.GetByPersonIdAsync(id, pagination);

        if (result.Success)
            return Ok(result);

        if (result.ErrorCode == OperationCode.EntityWasNotFound)
            return NotFound(result);

        return BadRequest(result);
    }

    /// <summary>
    /// Создание новой комнаты
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<ActionResult<OperationResult<int>>> Create(RoomCreateRequest request)
    {
        var result = await _roomService.CreateAsync(request);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    /// <summary>
    /// Редактирование существующей комнаты
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public async Task<ActionResult<OperationResult<int>>> Update(RoomUpdateRequest request)
    {
        var result = await _roomService.UpdateAsync(request);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    /// <summary>
    /// Удаление комнаты
    /// </summary>
    /// <param name="id">id комнаты</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<OperationResult<int>>> Delete(int id)
    {
        var result = await _roomService.DeleteAsync(id);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}