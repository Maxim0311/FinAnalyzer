using FinAnalyzer.Data.EntityFramework;
using FinAnalyzer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var user = _context.Persons.Find(1);

            var roomsList = user.Rooms;
            
            var test = _context.Rooms.Find(1);
            return Ok(test);
        }
    }
}