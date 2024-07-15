using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class RamValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.RamStick == null)
        {
            throw new ArgumentException("computer must have RamSticks", nameof(computer));
        }

        if (computer.RamStick.Any(ramStick => ramStick.DdrType.GetType() != computer.Motherboard.DdrType.GetType()))
        {
            throw new ArgumentException("Ram's ddr type doesn't match motherboard's ddr type", nameof(computer));
        }
    }
}