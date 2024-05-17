using Microsoft.AspNetCore.Mvc;

namespace ConsuleAndVault.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var dbPassword = _configuration["myapp/dbpassword"];
            var consulConnString = _configuration["db:connstring"];
            var configValues = new
            {
                DbPassword = dbPassword,
                ConsulCatalog = consulConnString
            };

            return Ok(configValues);
        }
    }
}
