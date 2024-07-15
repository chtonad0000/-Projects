using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineBase
{
    protected EngineBase(int engineSpeed, int engineFuelPerKilometre, int engineStartCost)
    {
        if (engineSpeed <= 0)
        {
            throw new ArgumentException("engineSpeed must be positive", nameof(engineSpeed));
        }

        if (engineStartCost <= 0)
        {
            throw new ArgumentException("engineStartCost must be positive", nameof(engineStartCost));
        }

        if (engineFuelPerKilometre <= 0)
        {
            throw new ArgumentException("engineFuelPerKilometre must be positive", nameof(engineFuelPerKilometre));
        }

        EngineSpeed = engineSpeed;
        EngineFuelPerKilometre = engineFuelPerKilometre;
        EngineStartCost = engineStartCost;
        EngineFuelAmount = 0;
    }

    public int EngineSpeed { get; private set;  }
    public int EngineFuelAmount { get; private set; }
    public int EngineFuelPerKilometre { get; private set;  }
    public int EngineStartCost { get; private set;  }
    public bool HasFuel => EngineFuelAmount >= 0;

    public void Refuel(int fuelAmount)
    {
        EngineFuelAmount += fuelAmount;
    }

    public void StartEngine()
    {
        EngineFuelAmount -= EngineStartCost;
    }

    public void FuelWaste(int distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        EngineFuelAmount -= distance * EngineFuelPerKilometre;
    }
}