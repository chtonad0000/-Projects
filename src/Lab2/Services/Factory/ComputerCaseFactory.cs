using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factory;

public class ComputerCaseFactory : FactoryBase<ComputerCase>
{
    public ComputerCaseFactory(IEnumerable<ComputerCase> computerCaseList)
        : base(computerCaseList)
    {
    }
}