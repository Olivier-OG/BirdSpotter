using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Birds;

namespace Services.Birds;

public class BirdService : IBirdService
{
    private readonly ApplicationDbContext dbContext;

    public BirdService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    ///     TODO Optimize this function
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<BirdDto.Index>> GetIndexAsync()
    {
        var birds = dbContext.Birds.Include(x => x.Spots).ToList();

        var response = new List<BirdDto.Index>();

        foreach (var bird in birds)
            response.Add(new BirdDto.Index
            {
                Id = bird.Id,
                Name = bird.Name,
                ImageUrl = bird.ImageUrl,
                AmountOfSpots = bird.Spots.Count
            });
        return response;
    }

    public async Task SpotAsync(BirdDto.Spot model)
    {
        var bird = await dbContext.Birds.SingleAsync(b => b.Id == model.BirdId);

        if (bird is null)
            throw new EntityNotFoundException(nameof(bird), model.BirdId);

        bird.SpottedAt(model.Longitude,
            model.Latitude,
            model.Spotter,
            model.Remark,
            model.SpottedOn);

        dbContext.Birds.Update(bird);
        
        await dbContext.SaveChangesAsync();
    }
}