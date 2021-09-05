using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecFlowCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]string location)
        {
            int start = 0;
            int change = 0;
            string summary = "";

            if (location == "Wroclaw")
            {
                start = 25;
                change = 1;
                summary = "Hot";
            }
            if (location == "Arctic")
            {
                start = -10;
                change = -2;
                summary = "Freezing";
            }

            var temp = start;

            var result = Enumerable.Range(1, 3).Select(index =>
                {
                    temp += change;
                    return new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = temp,
                        Summary = summary
                    };
                })
                .ToArray();

            return result;
        }

        [HttpGet("certainty")]
        public decimal GetCertainty([FromQuery]int days)
        {
            var result = 100 - (days * 7.5m);

            return result;
        }
    }
}
