using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Shared;
using BlazorApp.Shared.Weather;
using Microsoft.JSInterop;
using Blazor.HydrateState;

namespace BlazorApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherService, Services.WeatherService>();

            /* With hydrator */
            builder.Services.AddSingleton(services => new StateProvider<WeatherState>(Rehydrator.GetState(services, WeatherState.Default)));

            /* Without hydrator */
            //builder.Services.AddSingleton(services => new StateProvider<WeatherState>(WeatherState.Default));

            builder.Services.AddScoped<WeatherActions>();

            await builder.Build().RunAsync();
        }
    }
}
