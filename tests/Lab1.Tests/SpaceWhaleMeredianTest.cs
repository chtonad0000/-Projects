using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceWhaleMeredianTest
{
    [Fact]
    public void PathTestWhaleMeredian()
    {
        ResultBase result;
        const int fuelAmount = 100000;
        const int range = 1000;
        const int whalesPopulation = 1;
        Ship ship = new Meredian();

        var nebulaeNitrine = new NebulaeNitrine(new Collection<ObstacleBase> { new SpaceWhale(whalesPopulation) });
        var path = new Path(new Collection<PathSegment> { new PathSegment(nebulaeNitrine, range) });

        ship.Engine.Refuel(fuelAmount);
        result = PathCheckService.PathComplete(path, ship);

        Assert.True(ship.Deflector?.IsOn);
        Assert.Equal(typeof(SuccessResult), result.GetType());
    }
}