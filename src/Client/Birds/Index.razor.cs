using Microsoft.AspNetCore.Components;
using Shared.Birds;

namespace Client.Birds;

public partial class Index
{
    private IEnumerable<BirdDto.Index>? birds;

    [Inject] public IBirdService BirdService { get; set; } = default!;

    protected override async Task OnParametersSetAsync()
    {
        await FetchBirdsAsync();
    }

    private async Task FetchBirdsAsync()
    {
        birds = await BirdService.GetIndexAsync();
    }
}