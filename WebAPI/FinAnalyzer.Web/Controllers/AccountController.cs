using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Account;
using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{roomId}")]
    public async Task<ActionResult<OperationResult<AccountResponse>>> GetAll(int roomId)
    {
        var response = await _accountService.GetAll(roomId);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("get-by-person")]
    public async Task<ActionResult<OperationResult<AccountResponse>>> GetByPerson(int roomId, int personId)
    {
        var response = await _accountService.GetByPerson(roomId, personId);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("create")]
    public async Task<ActionResult<OperationResult<int>>> Create(AccountCreateRequest request)
    {
        var response = await _accountService.Create(request);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("get-account-types")]
    public async Task<ActionResult<OperationResult<AccountResponse>>> GetAccountTypes()
    {
        var response = await _accountService.GetAllAccountTypes();

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }
}

