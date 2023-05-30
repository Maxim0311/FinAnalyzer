using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface IStatisticService
{
    /// <summary>
    /// Получить статистику по категориям
    /// </summary>
    /// <param name="startDt"></param>
    /// <param name="endDt"></param>
    /// <returns></returns>
    Task<OperationResult<IEnumerable<CategoriesStatsResponse>>> GetCategoriesStatistic(int roomId, DateTime? startDt, DateTime? endDt);
}
