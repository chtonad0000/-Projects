using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : Ship
{
    public Vaklas()
        : base(new EngineE(), new DeflectorClass1(null), new ArmorClass2(), new EngineGamma(), null)
    {
    }
}