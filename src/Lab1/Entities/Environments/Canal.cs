using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Canal
{
    public Canal(int distance, int countAntimatterFlashes)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("distance must be positive", nameof(distance));
        }

        if (countAntimatterFlashes < 0)
        {
            throw new ArgumentException("countAntimatterFlashes musnt't be negative", nameof(countAntimatterFlashes));
        }

        Distance = distance;
        CountAntimatterFlashes = countAntimatterFlashes;
    }

    public int Distance { get; private set; }
    public int CountAntimatterFlashes { get; private set; }
}