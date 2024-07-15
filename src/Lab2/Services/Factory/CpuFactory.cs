using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class CpuFactory : FactoryBase<Cpu>
{
    public CpuFactory(IEnumerable<Cpu> cpuList)
    : base(cpuList)
    {
    }
}