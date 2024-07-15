using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : EnvironmentBase
{
    public Space(IEnumerable<ObstacleBase> obstacles)
        : base(obstacles)
    {
        if (!obstacles.All(obstacle => obstacle is SmallAsteroid or Meteorite))
        {
            throw new ArgumentException("All obstacles must be Antimatter", nameof(obstacles));
        }
    }
}