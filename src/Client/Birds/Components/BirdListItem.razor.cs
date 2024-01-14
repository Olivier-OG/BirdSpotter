using Microsoft.AspNetCore.Components;
using Shared.Birds;

namespace Client.Birds.Components;

public partial class BirdListItem
{
    [Parameter, EditorRequired]
    public BirdDto.Index Bird { get; set; } = null!;


    public void Spotted()
    {
        throw new NotImplementedException();
    }
}