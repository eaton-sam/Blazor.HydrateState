using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.HydrateState
{
    public class Rehydrator
    {
        public static T GetState<T>(IServiceProvider services, T defaultValue)
        {
            var interop = (IJSInProcessRuntime)services.GetRequiredService<IJSRuntime>();
            var valueFromState = interop.Invoke<T>("__hydrateState.getState", typeof(T).Name);
            return valueFromState ?? defaultValue;
        }
    }
}
