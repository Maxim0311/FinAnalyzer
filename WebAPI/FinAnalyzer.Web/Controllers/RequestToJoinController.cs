using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto;
using FinAnalyzer.Core.Dto.Person;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers;

[Route("api/request-to-join")]
[ApiController]
public class RequestToJoinController : ControllerBase
{
    private readonly IRequestToJoinRepository _repository;

    private readonly IMapper _mapper;

    public RequestToJoinController(IRequestToJoinRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetAll(int roomId)
    {
        var response = await _repository.GetAllAsync(roomId);
        return Ok(OperationResult.Ok(response.Where(x => x.Status == RequestToJoinStatus.New).Select(x => new RequestToJoinResponse
        {
            Id =x.Id,
            Person = _mapper.Map<PersonResponse>(x.Person),
            RoomId = x.RoomId,
            Status = x.Status,
            DateTime = x.CreateDate,

        })));
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
