using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineOmega : EngineJumpBase
{
    private const int Range = 5000;
    private const int FuelPerKm = 10;
    public EngineOmega()
        : base(Range, FuelPerKm)
    {
    }

    public override void FuelWaste(int distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        FuelAmount -= distance * (int)Math.Log(distance) * FuelPerKilometre;
    }
}