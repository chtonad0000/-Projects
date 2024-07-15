using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorBase
{
    protected DeflectorBase(int healthPoints, AntimatterDeflectorBase? antimatterModification)
    {
        if (healthPoints <= 0)
        {
            throw new ArgumentException("healthPoints must be positive", nameof(healthPoints));
        }

        HealthPoints = healthPoints;
        AntimatterModification = antimatterModification;
    }

    public int HealthPoints { get; protected set; }
    public AntimatterDeflectorBase? AntimatterModification { get; protected set; }
    public bool IsOn => HealthPoints > 0;
    public bool HasAntimatterDefend => AntimatterModification != null && AntimatterModification.IsAlive;
    public int SmallAsteroidDamage { get; init; }
    public int MeteoriteDamage { get; init; }
    public int SpaceWhaleDamage { get; init; }
    public int AntimatterDamage { get; init; }
    public void AddModification(AntimatterDeflectorBase modification)
    {
        AntimatterModification = modification;
    }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is Antimatter && AntimatterModification != null)
        {
            AntimatterModification.TakeDamage();
        }

        if (obstacle is Meteorite)
        {
            HealthPoints -= MeteoriteDamage;
        }

        if (obstacle is SmallAsteroid)
        {
            HealthPoints -= SmallAsteroidDamage;
        }

        if (obstacle is SpaceWhale)
        {
            HealthPoints -= SpaceWhaleDamage;
        }
    }
}