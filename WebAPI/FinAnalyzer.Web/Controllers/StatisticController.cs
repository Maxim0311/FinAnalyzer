using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers;

[Route("api/statistic")]
[ApiController]
public class StatisticController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    /// <summary>
    /// Получить статистику по категориям.
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="startDt"></param>
    /// <param name="endDt"></param>
    /// <returns></returns>
    [HttpGet("get-categories-statistic")]
    public async Task<IActionResult> GetCategoriesStatistic(int roomId, DateTime? startDt, DateTime? endDt)
    {
        var response = await _statisticService.GetCategoriesStatistic(roomId, startDt, endDt);
        return Ok(response);
    }
}
