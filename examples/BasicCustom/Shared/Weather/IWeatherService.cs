using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Weather
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeatherForecast();
    }
}
