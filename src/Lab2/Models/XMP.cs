using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Xmp
{
    public Xmp(Collection<int> timings, double voltage, double frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public IEnumerable<int> Timings { get; private set; }
    public double Voltage { get; private set; }
    public double Frequency { get; private set; }
}