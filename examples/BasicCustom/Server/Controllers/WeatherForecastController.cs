using BlazorApp.Shared;
using BlazorApp.Shared.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(IWeatherService weatherService)
        {
            WeatherService = weatherService;
        }

        public IWeatherService WeatherService { get; }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            await Task.Delay(1000);
            return await WeatherService.GetWeatherForecast();
        }
    }
}
