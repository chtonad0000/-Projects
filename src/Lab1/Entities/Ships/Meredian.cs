using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Emitters;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meredian : Ship
{
    public Meredian()
        : base(new EngineE(), new DeflectorClass2(null), new ArmorClass2(), null, new NitrineEmitter())
    {
    }
}