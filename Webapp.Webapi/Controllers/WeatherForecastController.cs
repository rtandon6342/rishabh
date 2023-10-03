using Microsoft.AspNetCore.Mvc;

namespace Webapp.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("Download")]  
    public IActionResult DownloadFromUrl()  
    {  
        var weatherForecast = new WeatherForecast();
        var bytes = weatherForecast.FileToByteArray("files/test.cvs");
        // var result = DownloadExtention.GetUrlContent(url);  
        Console.WriteLine("start download file");
        return File(bytes, "text/csv", "test.cvs");  
        // return Ok("file is not exist");  
    }
}
