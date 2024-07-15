using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class CpuValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Cpu.SocketType == null)
        {
            throw new ArgumentException("cpu must have socket", nameof(computer));
        }

        if (!computer.RamStick.All(ramStick => ramStick.MaxFrequency <= computer.Cpu.MaxRamFrequencies))
        {
            computer.Warranty = false;
            computer.WarrantyCommentary = new string("Ram won't work on max frequency");
        }

        if (computer.Cpu.SocketType.Name != computer.Motherboard.Socket.Name)
        {
            throw new ArgumentException("Cpu and motherboard have different sockets", nameof(computer));
        }

        if (!computer.Motherboard.Bios.SupportedCpus.Any(cpu =>
                cpu.Name.Equals(computer.Cpu.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("BIOS incompatible with this Cpu", nameof(computer));
        }

        if (computer.GpuAdapter == null && !computer.Cpu.GraphicCore)
        {
            throw new ArgumentException("Computer must have GpuAdapter or GraphicCore in Cpu", nameof(computer));
        }
    }
}