using Domain.Birds;
using Domain.Exceptions;

namespace Domain.Tests.Birds;

// ReSharper disable once InconsistentNaming
public class Bird_Should
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Not_Be_Created_Without_A_Name(string name)
    {

        Action act = () =>
        {
            Bird bird = new(name, "https://google.com");
        };

        act.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Throw_Exception_When_Spotted_At_Duplicate_Longitude_And_Latitude()
    {
        Bird bird = new("Canary", "https://google.com");
        bird.SpottedAt(0.0, 0.0, "Random", null, DateTime.Now);

        Action act = () =>
        {
            bird.SpottedAt(0.0, 0.0, "Random", null, DateTime.Now);
        };

        act.ShouldThrow<EntityAlreadyExistsException>();
    }

    [Fact]
    public void Add_Spot_When_Spotted()
    {
        Bird bird = new("Canary", "https://google.com");

        bird.SpottedAt(0.0, 0.0, "Random", null, DateTime.Now);

        bird.Spots.Count.ShouldBe(1);
    }
}

