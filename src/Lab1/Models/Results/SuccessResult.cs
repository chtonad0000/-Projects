using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public class SuccessResult : ResultBase
{
    public SuccessResult(int time, int impulseFuelAmount, int jumpFuelAmount)
    {
        if (time < 0)
        {
            throw new ArgumentException("time mustn't be negative", nameof(time));
        }

        if (impulseFuelAmount < 0)
        {
            throw new ArgumentException("impulseFuelAmount mustn't be negative", nameof(impulseFuelAmount));
        }

        if (jumpFuelAmount < 0)
        {
            throw new ArgumentException("jumpFuelAmount mustn't be negative", nameof(jumpFuelAmount));
        }

        Time = time;
        ImpulseFuelAmount = impulseFuelAmount;
        JumpFuelAmount = jumpFuelAmount;
    }

    public int Time { get; private set; }
    public int ImpulseFuelAmount { get; private set; }
    public int JumpFuelAmount { get; private set; }
}