using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class StateProvider<T>
    {
        public StateProvider(T initialValue) 
        {
            Value = initialValue;
        }

        public T Value { get; private set; }
        public event Action OnChange;

        internal void Set(T state)
        {
            if (!state.Equals(Value))
            {
                Value = state;
                OnChange?.Invoke();
            }
        }
    }
}
