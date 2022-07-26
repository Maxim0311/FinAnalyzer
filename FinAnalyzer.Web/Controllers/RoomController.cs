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

    [HttpGet("GetAll")]
    public async Task<ActionResult<PaginationResponse<RoomResponse>>> GetAll(string? searchText, int skip = 0, int take = 20)
    {
        var pagination = new PaginationRequest
        {
            SearchText = searchText,
            Skip = skip,
            Take = take
        };

        var response = await _roomService.GetAllAsync(pagination);

        if (response.Success)
            return Ok(response);

        if (response.ErrorCode == OperationCode.EntityWasNotFound)
            return NotFound(response);

        return BadRequest(response);
    }
    
    [HttpGet("getById")]
    public async Task<IActionResult> GetById()
    {

        return Ok(await _roomService.GetByIdAsync(1));
    }
}

