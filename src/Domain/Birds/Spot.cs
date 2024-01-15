namespace Domain.Birds;

public class Spot : Entity
{
    private DateTime spottedOn;

    /// <summary>
    ///     Entity Framework Core Constructor
    /// </summary>
    private Spot()
    {
    }

    public Spot(double longitude, double latitude, string? spotter, string? remark, DateTime spottedOn)
    {
        Longitude = longitude;
        Latitude = latitude;
        Spotter = spotter;
        Remark = remark;
        SpottedOn = spottedOn;
    }

    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string? Spotter { get; set; }
    public string? Remark { get; set; }

    public DateTime SpottedOn
    {
        get => spottedOn;
        set =>
            spottedOn = Guard.Against.OutOfRange(value, nameof(spottedOn), DateTime.Now.AddYears(-1), DateTime.Now);
    }
}