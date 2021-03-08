using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Weather
{
    public record WeatherState(WeatherForecast[] Forecasts)
    {
        public readonly static WeatherState Default = new WeatherState(Array.Empty<WeatherForecast>());
    }
}
