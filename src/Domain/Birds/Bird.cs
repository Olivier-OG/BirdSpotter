namespace Domain.Birds;

public class Bird : Entity
{
    private const double Tolerance = 0.0000000000001;
    private readonly List<Spot> spots = new();

    /// <summary>
    ///     Entity Framework Core Constructor
    /// </summary>
    private Bird()
    {
    }

    public Bird(string name, string imageUrl)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
        ImageUrl = Guard.Against.NullOrWhiteSpace(imageUrl);
    }

    public string Name { get; private set; } = default!;
    public string ImageUrl { get; private set; } = default!;
    public IReadOnlyList<Spot> Spots => spots.AsReadOnly();

    public void SpottedAt(double longitude, double latitude, string? spotter, string? remark, DateTime spottedOn)
    {
        var existsAtSamePos = Spots.Any(s =>
            Math.Abs(s.Longitude - longitude) < Tolerance &&
            Math.Abs(s.Latitude - latitude) < Tolerance
        );
        if (existsAtSamePos)
            throw new EntityAlreadyExistsException(nameof(Bird), "Longitude_Latitude", $"{longitude}, {latitude}");
        spots.Add(new Spot(longitude, latitude, spotter, remark, spottedOn));
    }
}