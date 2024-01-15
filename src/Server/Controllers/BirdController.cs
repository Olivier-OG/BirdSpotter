using Microsoft.AspNetCore.Mvc;
using Shared.Birds;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BirdController : ControllerBase
{
    private readonly IBirdService birdService;

    public BirdController(IBirdService birdService)
    {
        this.birdService = birdService;
    }

    [HttpGet]
    public async Task<IEnumerable<BirdDto.Index>> GetIndex()
    {
        return await birdService.GetIndexAsync();
    }

    [HttpPost]
    public async Task Spot([FromBody] BirdDto.Spot model)
    {
        await birdService.SpotAsync(model);
    }
}