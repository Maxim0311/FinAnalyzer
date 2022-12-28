using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Account;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using StafferyInternal.StafferyInternal.Common;

namespace FinAnalyzer.Core.Services.Implementation;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    
    private readonly IAccountTypeRepository _accountTypeRepository;

    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IMapper mapper, IAccountTypeRepository accountTypeRepository)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _accountTypeRepository = accountTypeRepository;
    }

    public async Task<OperationResult<IEnumerable<AccountResponse>>> GetAll(int roomId)
    {
        var accounts = await _accountRepository.GetAllByRoom(roomId);
        var response = _mapper.Map<IEnumerable<AccountResponse>>(accounts);

        if (accounts.Any())
            return OperationResult.Ok(response);

        return OperationResult.Fail<IEnumerable<AccountResponse>>
            (OperationCode.EntityWasNotFound, "Не найдено ни одного счёта");
    }

    public async Task<OperationResult<IEnumerable<AccountResponse>>> GetByPerson(int roomId, int personId)
    {
        var accounts = await _accountRepository.GetByPerson(roomId, personId);
        var response = _mapper.Map<IEnumerable<AccountResponse>>(accounts);

        if (accounts.Any())
            return OperationResult.Ok(response);

        return OperationResult.Fail<IEnumerable<AccountResponse>>
            (OperationCode.EntityWasNotFound, "Не найдено личных счетов");
    }

    public async Task<OperationResult<int>> Create(AccountCreateRequest request)
    {
        var account = _mapper.Map<Account>(request);
        var createdId = await _accountRepository.CreateAsync(account);
        return OperationResult.Ok(createdId);
    }

    public async Task<OperationResult<IEnumerable<(int Id, string Title)>>> GetAllAccountTypes()
    {
        var accounts = await _accountTypeRepository.GetAllAsync();

        if (accounts.Any())
            return OperationResult.Ok(accounts.Select(x => (x.Id, x.Title)));

        return OperationResult.Fail<IEnumerable<(int id, string title)>>
            (OperationCode.EntityWasNotFound, "Не найдено личных счетов");
    }
}

