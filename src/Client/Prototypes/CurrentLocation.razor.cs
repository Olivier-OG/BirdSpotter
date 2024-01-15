using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Client.Prototypes;

public partial class CurrentLocation
{
    private string latitude;
    private string longitude;

    [Inject] private IJSRuntime JsRuntime { get; set; } = default!;

    private async Task GetLocationAsync()
    {
        var position = await JsRuntime.InvokeAsync<string>("getLocation");
    Console.WriteLine(position);
        latitude = position.Split(";")[0];
        longitude = position.Split(";")[1];
    }
}