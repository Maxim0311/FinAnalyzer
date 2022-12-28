using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<IEnumerable<Account>> GetAllByRoom(int roomId);

    Task<IEnumerable<Account>> GetByPerson(int roomId, int personId);

    Task<bool> UpdateAsync(Account account);

    /// <summary>
    /// Зачислить деньги на счёт
    /// </summary>
    /// <param name="account"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    Task DepositMoney(int accountId, decimal amount);

    /// <summary>
    /// Снять деньги с счёта
    /// </summary>
    /// <param name="account"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    Task<bool> WithdrowMoney(int accountId, decimal amount);

    /// <summary>
    /// Перевести с счёта на другой счёт (false - если один из счетов не существует, либо недостаточно средств)
    /// </summary>
    /// <param name="senderId"></param>
    /// <param name="destinationId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    Task<bool> TransactMoney(int senderId, int destinationId, decimal amount);
}

