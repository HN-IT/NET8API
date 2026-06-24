using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [ActionName("Version2")]
        public IEnumerable<WeatherForecast> Version2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + " - Version 2"
            })
            .ToArray();
        }

        [HttpGet]
        [ActionName("Version3")]
        public IEnumerable<WeatherForecast> Version3()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + " - Version 3"
            })
            .ToArray();
        }
    }
}
