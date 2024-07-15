using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class CaseValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Case.MaxGpuSize == null)
        {
            throw new ArgumentException("Computer case must have MAxGpuSize", nameof(computer));
        }

        if (computer.Case.Size == null)
        {
            throw new ArgumentException("case must have Size", nameof(computer));
        }

        if (computer.GpuAdapter != null)
        {
            if (computer.GpuAdapter.Size.Length > computer.Case.MaxGpuSize.Length ||
                computer.GpuAdapter.Size.Height > computer.Case.MaxGpuSize.Height)
            {
                throw new ArgumentException("GruAdapter doesn't fit Case", nameof(computer));
            }
        }

        if (computer.Case.MotherboardFormFactors.All(formFactor =>
                formFactor.GetType() != computer.Motherboard.FormFactor.GetType()))
        {
            throw new ArgumentException("Motherboard doesn't fit the case", nameof(computer));
        }
    }
}