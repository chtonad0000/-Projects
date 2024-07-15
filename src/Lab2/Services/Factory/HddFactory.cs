using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class HddFactory : FactoryBase<Hdd>
{
    public HddFactory(IEnumerable<Hdd> hddList)
    : base(hddList)
    {
    }
}