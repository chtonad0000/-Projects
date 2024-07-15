using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class PowerBlockValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.PowerBlock == null)
        {
            throw new ArgumentException("computer must have power block", nameof(computer));
        }

        int sumPowerConsumption = 0;
        sumPowerConsumption += computer.Cpu.PowerConsumption;
        sumPowerConsumption += computer.RamStick.Sum(ramStick => ramStick.PowerConsumption);

        if (computer.WifiAdapter != null)
        {
            sumPowerConsumption += computer.WifiAdapter.PowerConsumption;
        }

        if (computer.GpuAdapter != null)
        {
            sumPowerConsumption += computer.GpuAdapter.PowerConsumption;
        }

        if (computer.Ssd != null)
        {
            sumPowerConsumption += computer.Ssd.PowerConsumption;
        }

        if (computer.Hdd != null)
        {
            sumPowerConsumption += computer.Hdd.PowerConsumption;
        }

        if (sumPowerConsumption > computer.PowerBlock.MaxPower)
        {
            computer.Warranty = false;
            computer.WarrantyCommentary = new string(
                "The power amount of PowerBlock may not be enough to power the entire computer");
        }
    }
}