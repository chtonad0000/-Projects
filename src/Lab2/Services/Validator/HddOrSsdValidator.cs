using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class HddOrSsdValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Ssd == null && computer.Hdd == null)
        {
            throw new ArgumentException("computer must have ssd or hdd", nameof(computer));
        }
    }
}