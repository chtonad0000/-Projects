using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Chipset
{
    public Chipset(string name, IEnumerable<double> availableFrequencies, bool hasXmp)
    {
        Name = name;
        AvailableFrequency = availableFrequencies;
        HasXmp = hasXmp;
    }

    public string Name { get; private set; }
    public IEnumerable<double> AvailableFrequency { get; private set; }
    public bool HasXmp { get; private set; }
}