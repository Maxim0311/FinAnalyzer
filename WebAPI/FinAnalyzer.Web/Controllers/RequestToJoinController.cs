using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers;

[Route("api/request-to-join")]
[ApiController]
public class RequestToJoinController : ControllerBase
{
    private readonly IRequestToJoinRepository _repository;

    public RequestToJoinController(IRequestToJoinRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetAll(int roomId)
    {
        return Ok(await _repository.GetAllAsync(roomId));
    }

    [HttpGet("apply")]
    public async Task Apply(int roomId, int personId)
    {
        await _repository.Apply(roomId, personId);
    }

    [HttpGet("accept")]
    public async Task Accept(int requestId)
    {
        await _repository.Accept(requestId);
    }

    [HttpGet("reject")]
    public async Task Reject(int requestId)
    {
        await _repository.Reject(requestId);
    }
}
