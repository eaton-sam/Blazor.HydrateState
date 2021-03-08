using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.HydrateState
{

    public class StateHydrator
    {
        private readonly IServiceProvider serviceProvider;
        private readonly StateHydratorOptions options;

        public StateHydrator(IServiceProvider serviceProvider, StateHydratorOptions options)
        {
            this.serviceProvider = serviceProvider;
            this.options = options;
        }

        public Dictionary<string, object> GetStates()
        {
            return options.Get().Select(x => (x.Key.Name, x.Value.Invoke(serviceProvider))).ToDictionary(x => x.Item1, x => x.Item2);
        }
    }
}
