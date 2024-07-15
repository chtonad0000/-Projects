namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Jedec
{
    public Jedec(double firstFreq, double secondFreq)
    {
        FirstFreq = firstFreq;
        SecondFreq = secondFreq;
    }

    public double FirstFreq { get; private set; }
    public double SecondFreq { get; private set; }
}