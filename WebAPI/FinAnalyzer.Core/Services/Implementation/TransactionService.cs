using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Transaction;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Services.Implementation;

public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    /// <summary>
    /// Доход
    /// </summary>
    /// <param name="transactionDto"></param>
    /// <returns></returns>
    public async Task<OperationResult> MakeIncomeTransaction(TransactionIncomeCreateRequest transactionDto)
    {
        var sender = new Account
        {
            Balance = 0,
            AccountTypeId = 3,
            Name = transactionDto.Sender,
            RoomId = transactionDto.RoomId
        };

        var transaction = new Transaction()
        {
            Amount = transactionDto.Amount,
            CategoryId = transactionDto.CategoryId,
            RoomId = transactionDto.RoomId,
            Name = transactionDto.Name,
            Description = transactionDto.Description,
            DestinationId = transactionDto.Destination,
            Sender = sender,
            TransactionTypeId = 1,
            CreateDate = DateTime.UtcNow
        };

        if (!await _accountRepository.IsExistAsync(transactionDto.Destination))
            return OperationResult.Fail(StafferyInternal.StafferyInternal.Common.OperationCode.Error, "Счёта получателя не существует");

        await _accountRepository.DepositMoney(transactionDto.Destination, transaction.Amount);
        await _transactionRepository.CreateAsync(transaction);

        return OperationResult.Ok();
    }

    /// <summary>
    /// Расход
    /// </summary>
    /// <param name="transactionDto"></param>
    /// <returns></returns>
    public async Task<OperationResult> MakeExpendTransaction(TransactionExpendCreateRequest transactionDto)
    {
        var destination = new Account
        {
            Balance = 0,
            AccountTypeId = 3,
            Name = transactionDto.Destination,
            RoomId = transactionDto.RoomId
        };

        var transaction = new Transaction()
        {
            Amount = transactionDto.Amount,
            CategoryId = transactionDto.CategoryId,
            RoomId = transactionDto.RoomId,
            Name = transactionDto.Name,
            Description = transactionDto.Description,
            TransactionTypeId = 2,
            Destination = destination,
            SenderId = transactionDto.Sender,
            CreateDate = DateTime.UtcNow
        };

        if (!await _accountRepository.IsExistAsync(transactionDto.Sender))
            return OperationResult.Fail(StafferyInternal.StafferyInternal.Common.OperationCode.Error, "Счёта получателя не существует");

        var isSuccess = await _accountRepository.WithdrowMoney(transactionDto.Sender, transaction.Amount);

        if (!isSuccess)
            return OperationResult.Fail(StafferyInternal.StafferyInternal.Common.OperationCode.Error, "Недостаточно средств");

        await _transactionRepository.CreateAsync(transaction);

        return OperationResult.Ok();
    }

    /// <summary>
    /// Денежный перевод
    /// </summary>
    /// <param name="transactionDto"></param>
    /// <returns></returns>
    public async Task<OperationResult> MakePersonTransaction(TransactionPersonCreateRequest transactionDto)
    {
        var isSuccess = await _accountRepository.TransactMoney(transactionDto.Sender, transactionDto.Destination, transactionDto.Amount);
        if (!isSuccess)
            return OperationResult.Fail(StafferyInternal.StafferyInternal.Common.OperationCode.Error, "Недостаточно средств");

        var transaction = new Transaction()
        {
            Amount = transactionDto.Amount,
            CategoryId = transactionDto.CategoryId,
            RoomId = transactionDto.RoomId,
            Name = transactionDto.Name,
            Description = transactionDto.Description,
            DestinationId = transactionDto.Destination,
            TransactionTypeId = 3,
            SenderId = transactionDto.Sender,
            CreateDate = DateTime.UtcNow
        };

        await _transactionRepository.CreateAsync(transaction);

        return OperationResult.Ok();
    }
}

