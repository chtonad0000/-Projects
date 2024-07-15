using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validator;

public class CoolerValidator : IComputerValidator
{
    public void Valid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!computer.Cooler.Sockets.Any(socket =>
                socket.Name.Equals(computer.Motherboard.Socket.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("Cooler and motherboard have different sockets", nameof(computer));
        }

        if (computer.Cooler.Height >= computer.Case.Size.Height)
        {
            throw new ArgumentException("Cooler doesn't fit case", nameof(computer));
        }

        if (computer.Cpu.Tdp > computer.Cooler.MaxTdp)
        {
            computer.Warranty = false;
            computer.WarrantyCommentary = new string("Cpu may overheat");
        }
    }
}