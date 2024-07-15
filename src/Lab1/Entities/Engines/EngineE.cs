namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineE : EngineBase
{
    private const int Speed = 100;
    private const int FuelPerKm = 20;
    private const int StartFuelCost = 50;
    public EngineE()
        : base(Speed, FuelPerKm, StartFuelCost)
    {
    }
}