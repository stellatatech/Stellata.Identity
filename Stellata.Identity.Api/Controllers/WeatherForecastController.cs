using System.Collections;
using Microsoft.AspNetCore.Mvc;

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

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        List<string> keys = new List<string>();
        var envars = Environment.GetEnvironmentVariables();
        foreach (object envar in envars.Keys)
        {
            keys.Add(envar?.ToString() ?? "OOps");
        }
        
        return Enumerable.Range(0, envars.Count - 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = keys[index]
            })
            .ToArray();
    }
}