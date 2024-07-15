namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineJumpBase
{
    protected EngineJumpBase(int rangeDistance, int fuelPerKilometre)
    {
        RangeDistance = rangeDistance;
        FuelPerKilometre = fuelPerKilometre;
        FuelAmount = 0;
    }

    public int RangeDistance { get; private set;  }
    public int FuelAmount { get; protected set; }
    public int FuelPerKilometre { get; private set;  }
    public bool HasFuel => FuelAmount >= 0;
    public abstract void FuelWaste(int distance);
    public void Refuel(int fuelAmount)
    {
        FuelAmount += fuelAmount;
    }
}