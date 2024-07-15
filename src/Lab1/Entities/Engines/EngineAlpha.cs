using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineAlpha : EngineJumpBase
{
    private const int Range = 1000;
    private const int FuelPerKm = 10;
    public EngineAlpha()
        : base(Range, FuelPerKm)
    {
    }

    public override void FuelWaste(int distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        FuelAmount -= distance * FuelPerKilometre;
    }
}