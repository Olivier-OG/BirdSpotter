namespace Domain.Birds;

public class Spot : Entity
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
	public string? Spotter { get; set; }
	public string? Remark { get; set; }
	/// <summary>
	/// TODO
	/// </summary>
    public DateTime SpottedOn { get; set; }

    /// <summary>
    /// Entity Framework Core Constructor
    /// </summary>
    private Spot() { }

	public Spot(double longitude, double latitude, string? spotter, string? remark, DateTime spottedOn)
	{
		Longitude = longitude;
		Latitude = latitude;
		Spotter = spotter;
		Remark = remark;
		SpottedOn = spottedOn;
    }
}