using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class EnvironmentBase
{
    protected EnvironmentBase(IEnumerable<ObstacleBase> obstacles)
    {
        if (obstacles == null)
        {
            throw new ArgumentNullException(nameof(obstacles));
        }

        Obstacles = obstacles;
    }

    public IEnumerable<ObstacleBase> Obstacles { get; private set; }
}