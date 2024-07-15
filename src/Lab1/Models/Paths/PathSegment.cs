using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;

public class PathSegment
{
    public PathSegment(EnvironmentBase environment, int distance)
    {
        if (environment == null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        Environment = environment;
        Distance = distance;
    }

    public EnvironmentBase Environment { get; private set; }
    public int Distance { get; private set; }
}