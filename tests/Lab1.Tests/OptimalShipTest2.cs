using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class OptimalShipTest2
{
    [Fact]
    public void BetterShipTest()
    {
        Ship? betterShip;
        const int fuelAmount = 1000000;
        var avgur = new Avgur();
        var stella = new Stella();
        var nebulaeDensity = new NebulaeDensity(new Collection<ObstacleBase>(), new Collection<Canal> { new Canal(100, 0), new Canal(3000, 0), new Canal(4563, 0) });
        var path = new Path(new Collection<PathSegment> { new PathSegment(nebulaeDensity, 7663) });

        avgur.Engine.Refuel(fuelAmount);
        avgur.EngineJump?.Refuel(fuelAmount);
        stella.Engine.Refuel(fuelAmount);
        stella.EngineJump?.Refuel(fuelAmount);
        betterShip = BetterShipService.BetterShip(path, avgur, stella);

        Assert.IsType<Stella>(betterShip);
    }
}