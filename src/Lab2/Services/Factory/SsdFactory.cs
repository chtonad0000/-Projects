using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class SsdFactory : FactoryBase<Ssd>
{
    public SsdFactory(IEnumerable<Ssd> ssdList)
    : base(ssdList)
    {
    }
}