using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Avgur : Ship
{
    public Avgur()
        : base(new EngineE(), new DeflectorClass3(null), new ArmorClass3(), new EngineAlpha(), null)
    {
    }
}