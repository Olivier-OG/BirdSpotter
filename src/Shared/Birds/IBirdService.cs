namespace Shared.Birds;

public interface IBirdService
{
    Task<IEnumerable<BirdDto.Index>> GetIndexAsync();
    Task SpotAsync(BirdDto.Spot model);
}
