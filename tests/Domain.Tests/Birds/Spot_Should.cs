using System;
using Domain.Birds;

namespace Domain.Tests.Birds;

// ReSharper disable once InconsistentNaming
public class Spot_Should
{
    [Theory]
    [InlineData(0.01, 0.01, "Olivier", "Up In A Tree")]    
    [InlineData(0.03, 0.02, "Olivier", null)]
    public void Be_Created_With_Valid_Params(double longitude, double latitude, string spotter, string? remark)
    {
        var act = () =>
        {
            Spot spot =  new(longitude, latitude, spotter, remark, DateTime.Today);
        };

        act.ShouldNotThrow();
    }
    
    [Theory]
    [InlineData(0.01, 0.01, "Olivier", "Up In A Tree")]    
    [InlineData(0.03, 0.02, "Olivier", null)]
    public void Not_Be_Created_With_Invalid_SpottedOn(double longitude, double latitude, string spotter, string? remark)
    {
        var act = () =>
        {
            Spot spot =  new(longitude, latitude, spotter, remark, DateTime.Today);
        };

        act.ShouldNotThrow();
    }

    // [Theory]
    // public void Throw_Exception_When_Set_Invalid_SpottedOn(DateTime spottedOn)
    // {
    //     
    // }

}

