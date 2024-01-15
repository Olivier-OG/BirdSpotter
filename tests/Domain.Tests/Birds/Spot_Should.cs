using Domain.Birds;

namespace Domain.Tests.Birds;

// ReSharper disable once InconsistentNaming
public class Spot_Should
{
    public static IEnumerable<object[]> Source => new List<object[]>
    {
        new object[] { new DateTime(2024, 1, 16) },
        new object[] { new DateTime(2023, 1, 13) }
    };

    [Theory]
    [InlineData(0.01, 0.01, "Olivier", "Up In A Tree")]
    [InlineData(0.02, 0.02, null, "Up In A Tree")]
    [InlineData(0.03, 0.03, "Olivier", null)]
    public void Be_Created_With_Valid_Params(double longitude, double latitude, string? spotter, string? remark)
    {
        var act = () =>
        {
            Spot spot = new(longitude, latitude, spotter, remark, DateTime.Now);
        };

        act.ShouldNotThrow();
    }

    [Theory]
    [MemberData(nameof(Source))]
    public void Not_Be_Created_With_Invalid_SpottedOn(DateTime spottedOn)
    {
        var act = () =>
        {
            Spot spot = new(0.01, 0.01, "Olivier", "Up In A Tree", spottedOn);
        };

        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Theory]
    [MemberData(nameof(Source))]
    public void Throw_Exception_When_Set_Invalid_SpottedOn(DateTime spottedOn)
    {
        Spot spot = new(0.01, 0.01, "Olivier", "Up In A Tree", DateTime.Now);

        var act = () => { spot.SpottedOn = spottedOn; };

        act.ShouldThrow<ArgumentOutOfRangeException>();
    }
}