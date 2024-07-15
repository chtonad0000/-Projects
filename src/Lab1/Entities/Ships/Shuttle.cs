using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : Ship
{
    public Shuttle()
        : base(new EngineC(), null, new ArmorClass1(), null, null)
    {
    }
}