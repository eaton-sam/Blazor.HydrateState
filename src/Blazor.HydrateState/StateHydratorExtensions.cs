using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.HydrateState
{
    public static class StateHydratorExtensions
    {
        public static void AddStateHydrator(this IServiceCollection serviceCollection, Action<StateHydratorOptions> optionsCallback)
        {
            var options = new StateHydratorOptions();
            optionsCallback(options);
            serviceCollection.AddSingleton(options);
            serviceCollection.AddScoped<StateHydrator>();
        }
    }
}
