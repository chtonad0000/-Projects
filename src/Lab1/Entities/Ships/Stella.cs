using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : Ship
{
    public Stella()
        : base(new EngineC(), new DeflectorClass1(null), new ArmorClass1(), new EngineOmega(), null)
    {
    }
}