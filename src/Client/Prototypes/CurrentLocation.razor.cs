using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Client.Prototypes;

public partial class CurrentLocation
{
    private string longitude;
    private string latitude;
    private async Task GetLocationAsync()
    {
        longitude = "Not calculated....";
        latitude = "Not calculated....";
    }
}

