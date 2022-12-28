using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Account;

namespace FinAnalyzer.Core.Services.Interfaces;

/// <summary>
/// Сервис работы со счетами
/// </summary>
public interface IAccountService
{
    Task<OperationResult<IEnumerable<AccountResponse>>> GetAll(int roomId);

    Task<OperationResult<IEnumerable<AccountResponse>>> GetByPerson(int roomId, int personId);

    Task<OperationResult<int>> Create(AccountCreateRequest request);

    Task<OperationResult<IEnumerable<(int Id, string Title)>>> GetAllAccountTypes();
}

