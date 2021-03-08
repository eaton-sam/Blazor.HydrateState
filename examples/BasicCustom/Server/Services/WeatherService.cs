using BlazorApp.Shared.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private WeatherForecast[] forecasts;

        public WeatherService()
        {
            var rng = new Random();
            forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public Task<WeatherForecast[]> GetWeatherForecast()
        {
            return Task.FromResult(forecasts);
        }
    }
}
