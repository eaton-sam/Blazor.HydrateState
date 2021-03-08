# Blazor.HydrateState

## State hydration for server pre-rendered Blazor WASM apps

When you pre-render a Blazor App on the server, your application state is never sent to the client. Once your app loads in the browser it has to fetch data from your API to repopulate state. This causes your UI to flash, and means often unnecessary extra API calls.

Blazor.HydrateState will dehydrate your state on backend render, and rehydrate it on the frontend. Which is a silly way of saying that it serializes your state and deserializes it again.

<details>
  <summary>Demonstration</summary
    
  Blazor WASM only:
  ![wasm.gif](https://s4.gifyu.com/images/wasm.gif)
  
  Server pre-rendered WASM:
  ![wasm-prerendered.gif](https://s4.gifyu.com/images/wasm-prerendered.gif)
  
  Server pre-rendered WASM with Blazor.HydrateState:
  ![wasm-prerendered-hydrate.gif](https://s4.gifyu.com/images/wasm-prerendered-hydrate.gif)
</details>


## Usage
The following example can be found in full at /examples/BasicCustom

Consider you have a class ``WeatherState``, which holds weather forecasts. You may also have a class ``StateProvider<T>`` which handles state access, updates and firing change events to components.

<details>
  <summary>WeatherState.cs</summary>
  
  ```csharp
    public record WeatherState(WeatherForecast[] Forecasts)
    {
        public readonly static WeatherState Default = new WeatherState(Array.Empty<WeatherForecast>());
    }
  ```
</details>

<details>
  <summary>StateProvider.cs</summary>
  
  ```csharp
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
  ```
</details>

### On the server
In ``ConfigureServices`` call ``AddStateHydrator``, passing in an action to setup your `StateHydratorOptions`.

In your options action, you should add any state you wish to rehydrate on the frontend.

```csharp
services.AddStateHydrator(options =>
{
    //this will attempt to resolve the type from DI service collection
    options.Add<WeatherState>();
    //pass a function to retrieve your state instance
    options.Add<WeatherState>(sp => sp.GetService<StateProvider<WeatherState>>().Value);
});
```

At the bottom of your ``_Host.cshtml``, before framework js, add the ``Dehydrator`` component and the interop.js script.

```html
<html>
...
  <body>
  ...
    <component type="typeof(Blazor.HydrateState.Dehydrator)" render-mode="Static" />
    <script src="_content/Blazor.HydrateState/interop.js"></script>
    <script src="_framework/blazor.webassembly.js"></script>
  </body>
</html>
```

### On the client
In your ``Program.cs`` add your DI for your state, using ``Rehydrator.GetState`` to set the initial value to the value we dehydrated on the server

```csharp
builder.Services.AddSingleton(services => Rehydrator.GetState(services, WeatherState.Default));
//or if using a 'state provider'
builder.Services.AddSingleton(services => new StateProvider<WeatherState>(Rehydrator.GetState(services, WeatherState.Default)));
```

Your component will then render on the client with the same state as the backend, avoiding the flash/content change. 
In your components you can check if your state is populated in your init, skipping some API requests on the client entirely.


Check the example for better context.
