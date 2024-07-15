using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MyOptimalShipTest
{
    [Fact]
    public void BetterShipTest()
    {
        const int fuelAmount = 1000000;
        var meredian = new Meredian();
        var avgur = new Avgur();
        var avgur2 = new Avgur();
        var shuttle = new Shuttle();
        var space = new Space(new Collection<ObstacleBase>());
        var nebulaeDensity = new NebulaeDensity(new Collection<ObstacleBase> { new Antimatter() }, new Collection<Canal>
            { new Canal(100, 2), new Canal(1000, 0) });
        var space2 = new Space(new Collection<ObstacleBase>
            { new Meteorite(), new Meteorite(), new SmallAsteroid(), new Meteorite(), new SmallAsteroid() });
        var nebulaeNitrine = new NebulaeNitrine(new Collection<ObstacleBase> { new SpaceWhale(1) });
        var path = new Path(new Collection<PathSegment>
            { new PathSegment(space, 100), new PathSegment(nebulaeDensity, 1100), new PathSegment(space2, 1000), new PathSegment(nebulaeNitrine, 1560) });
        Ship? betterShip1;
        Ship? betterShip2;

        shuttle.Engine.Refuel(fuelAmount);
        avgur.Engine.Refuel(fuelAmount);
        avgur.EngineJump?.Refuel(fuelAmount);
        meredian.AddModification(new PhotonicDeflector());
        meredian.Engine.Refuel(fuelAmount);
        meredian.EngineJump?.Refuel(fuelAmount);
        avgur2.Engine.Refuel(fuelAmount);
        avgur2.EngineJump?.Refuel(fuelAmount);
        avgur2.AddModification(new PhotonicDeflector());

        betterShip1 = BetterShipService.BetterShip(path, shuttle, avgur);
        betterShip2 = BetterShipService.BetterShip(path, meredian, avgur2);

        Assert.Null(betterShip1);
        Assert.IsType<Avgur>(betterShip2);
    }
}