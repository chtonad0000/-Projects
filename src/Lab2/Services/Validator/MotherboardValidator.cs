using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class MotherboardValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Motherboard.Bios == null)
        {
            throw new ArgumentException("motherboard mut have Bios", nameof(computer));
        }

        if (computer.Motherboard.Chipset == null)
        {
            throw new ArgumentException("motherboard mut have chipset", nameof(computer));
        }

        if (computer.Motherboard.Socket == null)
        {
            throw new ArgumentException("motherboard mut have socket", nameof(computer));
        }

        if (computer.Motherboard.DdrType == null)
        {
            throw new ArgumentException("motherboard mut have ddrType", nameof(computer));
        }

        if (computer.Motherboard.FormFactor == null)
        {
            throw new ArgumentException("motherboard mut have Form factor", nameof(computer));
        }

        if (computer.WifiAdapter != null && computer.Motherboard.HasWifiAdapter)
        {
            throw new ArgumentException("Motherboard has wifiAdapter", nameof(computer));
        }

        int pcieComponents = 0;
        if (computer.GpuAdapter != null)
        {
            pcieComponents += 1;
        }

        if (computer.Ssd != null && computer.Ssd.PcieConnect)
        {
            pcieComponents += 1;
        }

        if (computer.WifiAdapter != null)
        {
            pcieComponents += 1;
        }

        if (pcieComponents > computer.Motherboard.PcieCount)
        {
            throw new ArgumentException("No free Pcie lines", nameof(computer));
        }

        if (computer.Hdd != null && computer.Motherboard.SataCount == 0)
        {
            throw new ArgumentException("No Sata Lines in motherboard", nameof(computer));
        }

        if (computer.Hdd != null && computer.Motherboard.SataCount == 1 && computer.Ssd != null &&
            computer.Ssd.SataConnect)
        {
            throw new ArgumentException("No free Sata Lines in motherboard, remove ssd", nameof(computer));
        }

        if (computer.RamStick.Count() > computer.Motherboard.RamSticksCount)
        {
            throw new ArgumentException("No enough space for all RamSticks", nameof(computer));
        }
    }
}