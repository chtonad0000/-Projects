using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class GpuFactory : FactoryBase<Gpu>
{
    public GpuFactory(IEnumerable<Gpu> gpuList)
    : base(gpuList)
    {
    }
}