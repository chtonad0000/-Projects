using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class NebulaeDensityPathTest
{
    [Theory]
    [InlineData(typeof(Shuttle))]
    [InlineData(typeof(Avgur))]
    public void UnSuccessPath(Type shipType)
    {
        const int fuelAmount = 1000;
        const int range = 2000;
        const int countAntimatterFlashes = 0;
        ResultBase result;
        Ship ship = new Shuttle();
        if (shipType == typeof(Avgur))
        {
            ship = new Avgur();
            ship.EngineJump?.Refuel(fuelAmount);
        }

        var nebulaeDensity = new NebulaeDensity(new Collection<ObstacleBase>(), new Collection<Canal> { new Canal(range, countAntimatterFlashes) });
        var path = new Path(new Collection<PathSegment> { new PathSegment(nebulaeDensity, range) });

        ship.Engine.Refuel(fuelAmount);
        result = PathCheckService.PathComplete(path, ship);

        Assert.Equal(typeof(ShipLostResult), result.GetType());
    }
}