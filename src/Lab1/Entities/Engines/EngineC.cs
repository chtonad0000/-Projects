namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class EngineC : EngineBase
{
    private const int Speed = 50;
    private const int FuelPerKm = 5;
    private const int StartFuelCost = 20;
    public EngineC()
        : base(Speed, FuelPerKm, StartFuelCost)
    {
    }
}