using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Shared.Birds;

namespace Server.Controllers.Birds;

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

    /// <summary>
    /// TODO: Implement a function which adds a spot for a bird.
    /// </summary>
}
