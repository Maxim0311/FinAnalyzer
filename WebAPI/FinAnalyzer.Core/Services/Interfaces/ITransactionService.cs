using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Transaction;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface ITransactionService
{
    Task<OperationResult> MakeIncomeTransaction(TransactionIncomeCreateRequest transactionDto);

    Task<OperationResult> MakeExpendTransaction(TransactionExpendCreateRequest transactionDto);

    Task<OperationResult> MakePersonTransaction(TransactionPersonCreateRequest transactionDto);

    Task<OperationResult<IEnumerable<TransactionResponse>>> GetAllTransactions(int roomId);
}