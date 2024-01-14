using Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Birds;
using Domain.Birds;
using Domain.Exceptions;

namespace Services.Birds;

public class BirdService : IBirdService
{
    private readonly ApplicationDbContext dbContext;

    public BirdService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    /// TODO Optimize this function
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<BirdDto.Index>> GetIndexAsync()
    {
        var birds = dbContext.Birds.Include(x => x.Spots).ToList();

        var response = new List<BirdDto.Index>();

        foreach (var bird in birds)
        {
            response.Add(new BirdDto.Index
            {
                Id = bird.Id,
                Name = bird.Name,
                ImageUrl = bird.ImageUrl,
                AmountOfSpots = bird.Spots.Count,
            });
        }
        return response;
    }


    /// <summary>
    /// TODO
    /// </summary>
    public async Task SpotAsync(BirdDto.Spot model)
    {
        throw new NotImplementedException("Implement this function.");
    }
}

