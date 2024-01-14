using System;
namespace Domain.Birds;

public class Bird : Entity
{
	private readonly List<Spot> spots = new();

	public string Name { get; private set; } = default!;
    public string ImageUrl { get; private set; } = default!;
    public IReadOnlyList<Spot> Spots => spots.AsReadOnly();

    /// <summary>
    /// Entity Framework Core Constructor
    /// </summary>
    private Bird() { }

    public Bird(string name, string imageUrl)
	{
		Name = Guard.Against.NullOrWhiteSpace(name);
		ImageUrl = Guard.Against.NullOrWhiteSpace(imageUrl);
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void SpottedAt(double longitude, double latitude, string? spotter, string? remark, DateTime spottedOn)
    {
        throw new NotImplementedException("Implement this function");
    }
}
