using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class AntimatterDeflectorBase
{
    protected AntimatterDeflectorBase(int antimatterDefendCount)
    {
        if (antimatterDefendCount <= 0)
        {
            throw new ArgumentException("antimatterDefendCount must be positive", nameof(antimatterDefendCount));
        }

        AntimatterDefendCount = antimatterDefendCount;
    }

    public int AntimatterDefendCount { get; private set; }
    public bool IsAlive => AntimatterDefendCount > 0;
    public void TakeDamage()
    {
        AntimatterDefendCount -= 1;
    }
}