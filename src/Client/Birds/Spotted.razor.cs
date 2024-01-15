using Microsoft.AspNetCore.Components;
using Shared.Birds;

namespace Client.Birds;

public partial class Spotted
{
    private readonly BirdDto.Spot model = new();
    private List<BirdDto.Index> birds = new();

    [Inject] private IBirdService BirdService { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    private async Task SubmitValidForm()
    {
        await BirdService.SpotAsync(model);
        NavigationManager.NavigateTo("/birds");
    }


    protected override async Task OnInitializedAsync()
    {
        await GetBirdsAsync();
    }


    private async Task GetBirdsAsync()
    {
        birds = (await BirdService.GetIndexAsync()).ToList();
    }
}