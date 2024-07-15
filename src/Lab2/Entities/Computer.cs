using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    public Computer(Motherboard motherboard, Cpu cpu, Cooler cooler, Collection<RamStick> ramSticks, ComputerCase computerCase, PowerBlock powerBlock)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Cooler = cooler;
        RamStick = ramSticks;
        Case = computerCase;
        PowerBlock = powerBlock;
    }

    public Motherboard Motherboard { get; set; }
    public Cpu Cpu { get; set; }
    public Cooler Cooler { get; set; }
    public IEnumerable<RamStick> RamStick { get; set; }
    public Xmp? XmpProfile { get; set; }
    public Gpu? GpuAdapter { get; set; }
    public Ssd? Ssd { get; set; }
    public Hdd? Hdd { get; set; }
    public ComputerCase Case { get; set; }
    public PowerBlock PowerBlock { get; set; }
    public WifiAdapter? WifiAdapter { get; set; }

    public bool Warranty { get; set; } = true;
    public string? WarrantyCommentary { get; set; }
}