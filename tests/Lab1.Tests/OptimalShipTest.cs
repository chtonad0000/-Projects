using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class OptimalShipTest
{
    [Fact]
    public void BetterShipTest()
    {
        Ship? betterShip;
        const int fuelAmount = 10000;
        var shuttle = new Shuttle();
        var vaklas = new Vaklas();
        var space = new Space(new Collection<ObstacleBase>());
        var path = new Path(new Collection<PathSegment> { new PathSegment(space, 100) });

        shuttle.Engine.Refuel(fuelAmount);
        vaklas.Engine.Refuel(fuelAmount);
        betterShip = BetterShipService.BetterShip(path, shuttle, vaklas);

        Assert.IsType<Shuttle>(betterShip);
    }
}