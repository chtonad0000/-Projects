using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AntimatterFlashTest
{
    [Theory]
    [InlineData(false, typeof(CrewDiedResult))]
    [InlineData(true, typeof(SuccessResult))]
    public void PathTestAntimatter(bool hasPhotonicDeflector, Type resultType)
    {
        const int fuelAmount = 100000;
        const int range = 100;
        const int countAntimatterFlashes = 2;
        ResultBase result;
        var ship = new Vaklas();
        var nebulaeDensity = new NebulaeDensity(new Collection<ObstacleBase>(), new Collection<Canal> { new Canal(range, countAntimatterFlashes) });
        var path = new Path(new Collection<PathSegment> { new PathSegment(nebulaeDensity, range) });

        ship.Engine.Refuel(fuelAmount);
        ship.EngineJump?.Refuel(fuelAmount);
        if (hasPhotonicDeflector)
        {
            ship.AddModification(new PhotonicDeflector());
        }

        result = PathCheckService.PathComplete(path, ship);

        Assert.Equal(resultType, result.GetType());
    }
}