using BlazorApp.Shared.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
    public class WeatherService : IWeatherService
    {
        public WeatherService(HttpClient http)
        {
            Http = http;
        }

        public HttpClient Http { get; }

        public async Task<WeatherForecast[]> GetWeatherForecast()
        {
            return await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
