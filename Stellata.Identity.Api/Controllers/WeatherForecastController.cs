using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Stellata.Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IOptions<AppSettings> _options;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AppSettings> options)
    {
        _logger = logger;
        _options = options;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        
        return Enumerable.Range(0, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _options?.Value?.ConnectionStrings?.Test ?? "HI"
            })
            .ToArray();
    }
}