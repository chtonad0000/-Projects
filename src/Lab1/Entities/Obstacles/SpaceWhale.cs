namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhale : ObstacleBase
{
    public SpaceWhale(int population)
    {
        Population = population;
    }

    public int Population { get; }
}