using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineGamma : EngineJumpBase
{
    private const int Range = 10000;
    private const int FuelPerKm = 10;
    public EngineGamma()
        : base(Range, FuelPerKm)
    {
    }

    public override void FuelWaste(int distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        FuelAmount -= distance * distance * FuelPerKilometre;
    }
}