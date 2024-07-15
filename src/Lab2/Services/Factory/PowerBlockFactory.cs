using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class PowerBlockFactory : FactoryBase<PowerBlock>
{
    public PowerBlockFactory(IEnumerable<PowerBlock> powerBlockList)
    : base(powerBlockList)
    {
    }
}