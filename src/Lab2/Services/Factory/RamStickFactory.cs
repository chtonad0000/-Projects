using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class RamStickFactory : FactoryBase<RamStick>
{
    public RamStickFactory(IEnumerable<RamStick> ramStickList)
    : base(ramStickList)
    {
    }
}