using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Weather
{
    public class WeatherActions
    {
        private readonly StateProvider<WeatherState> stateProvider;
        private readonly IWeatherService weatherService;

        public WeatherActions(StateProvider<WeatherState> stateProvider, IWeatherService weatherService)
        {
            this.stateProvider = stateProvider;
            this.weatherService = weatherService;
        }

        public async Task GetForecasts()
        {
            var forecasts = await weatherService.GetWeatherForecast();
            stateProvider.Set(stateProvider.Value with { Forecasts = forecasts });
        }
    }
}
