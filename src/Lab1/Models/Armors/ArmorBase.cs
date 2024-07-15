using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

public abstract class ArmorBase
{
    protected ArmorBase(int maxHitPoints)
    {
        if (maxHitPoints <= 0)
        {
            throw new ArgumentException("maxHitPoints must be positive", nameof(maxHitPoints));
        }

        HitPoints = maxHitPoints;
    }

    public int SmallAsteroidDamage { get; init; }
    public int MeteoriteDamage { get; init; }
    public int SpaceWhaleDamage { get; init; }
    public int AntimatterDamage { get; init; }

    public int HitPoints { get; protected set; }
    public bool IsAlive => HitPoints > 0;

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is Meteorite)
        {
            HitPoints -= MeteoriteDamage;
        }

        if (obstacle is SmallAsteroid)
        {
            HitPoints -= SmallAsteroidDamage;
        }

        if (obstacle is SpaceWhale)
        {
            HitPoints -= SpaceWhaleDamage;
        }
    }
}