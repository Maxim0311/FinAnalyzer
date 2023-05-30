using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Core.Services.Implementation;

public class StatisticService : IStatisticService
{
    private readonly ITransactionRepository _transactionRepository;

    public StatisticService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<OperationResult<IEnumerable<CategoriesStatsResponse>>> GetCategoriesStatistic(int roomId, DateTime? startDt, DateTime? endDt)
    {
        var transactions = await _transactionRepository.GetByRoomIdAsync(roomId);

        var groupedTransactions = transactions.GroupBy(x => x.Category).Take(5).ToDictionary(x => x.Key, y => y.Sum(t => t.Amount));
        var totalSum = groupedTransactions.Sum(x => x.Value);
        var result = groupedTransactions.Select(x => new CategoriesStatsResponse
        {
            Name = x.Key.Name,
            Color = x.Key.Color,
            Value = Math.Round((x.Value / totalSum) * 100)
        });
        return OperationResult.Ok(result);
    }
}
