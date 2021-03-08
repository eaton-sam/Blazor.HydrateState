using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Blazor.HydrateState
{
    public class StateHydratorOptions
    {
        private Dictionary<Type, Func<IServiceProvider, object>> stateTypes = new Dictionary<Type, Func<IServiceProvider, object>>();

        private static object GenericCreator<T>(IServiceProvider serviceProvider) => serviceProvider.GetService<T>();

        public Dictionary<Type, Func<IServiceProvider, object>> Get() => stateTypes;

        public void Add<T>() => stateTypes.Add(typeof(T), GenericCreator<T>);

        public void Add<T>(Func<IServiceProvider, T> creator) => stateTypes.Add(typeof(T), serviceProvider => creator(serviceProvider));
    }
}
