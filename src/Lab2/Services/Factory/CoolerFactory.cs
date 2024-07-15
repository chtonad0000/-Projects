using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class CoolerFactory : FactoryBase<Cooler>
{
    public CoolerFactory(IEnumerable<Cooler> coolerList)
    : base(coolerList)
    {
    }
}