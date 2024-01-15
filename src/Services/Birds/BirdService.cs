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

    public async Task<IEnumerable<BirdDto.Index>> GetIndexAsync()
    {
        var birds = await dbContext.Birds.Select(b => new BirdDto.Index
        {
            Id = b.Id,
            Name = b.Name,
            ImageUrl = b.ImageUrl,
            AmountOfSpots = b.Spots.Count
        }).ToListAsync();
        
        return birds;
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