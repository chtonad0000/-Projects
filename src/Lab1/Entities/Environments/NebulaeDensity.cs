using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaeDensity : EnvironmentBase
{
    public NebulaeDensity(IEnumerable<ObstacleBase> obstacles, IEnumerable<Canal> canalRanges)
        : base(obstacles)
    {
        CanalRanges = canalRanges;
        if (!obstacles.All(obstacle => obstacle is Antimatter))
        {
            throw new ArgumentException("All obstacles must be Antimatter", nameof(obstacles));
        }
    }

    public IEnumerable<Canal>? CanalRanges { get; private set; }
}