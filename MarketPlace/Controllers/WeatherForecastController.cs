using MarketPlace.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        MarketPlaceContext test;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IConfiguration config)
        {
            _logger = logger;
            test = new MarketPlaceContext(config);
        }

        [HttpGet("GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(test.Orders.FirstOrDefault());
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok(test.Orders.FirstOrDefault());
        }
    }
}