using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class BIOS
{
    public BIOS(string type, string version, IEnumerable<Cpu> supportedCpus)
    {
        Type = type;
        Version = version;
        SupportedCpus = supportedCpus;
    }

    public string Type { get; private set; }
    public string Version { get; private set; }
    public IEnumerable<Cpu> SupportedCpus { get; private set; }
}