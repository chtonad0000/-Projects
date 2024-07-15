using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class MotherboardFactory : FactoryBase<Motherboard>
{
    public MotherboardFactory(IEnumerable<Motherboard> motherboardList)
    : base(motherboardList)
    {
    }
}