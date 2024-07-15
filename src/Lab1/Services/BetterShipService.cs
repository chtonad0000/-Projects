using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class BetterShipService
{
    public static Ship? BetterShip(Path? path, Ship? shipA, Ship? shipB)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (shipA == null)
        {
            throw new ArgumentNullException(nameof(shipA));
        }

        if (shipB == null)
        {
            throw new ArgumentNullException(nameof(shipB));
        }

        const int impulseFuelPrice = 10;
        const int jumpFuelPrice = 20;
        ResultBase resultA = PathCheckService.PathComplete(path, shipA);
        ResultBase resultB = PathCheckService.PathComplete(path, shipB);
        switch (resultA)
        {
            case SuccessResult successA when resultB is SuccessResult successB:
            {
                int priceA = (successA.ImpulseFuelAmount * impulseFuelPrice) + (successA.JumpFuelAmount * jumpFuelPrice);
                int priceB = (successB.ImpulseFuelAmount * impulseFuelPrice) + (successB.JumpFuelAmount * jumpFuelPrice);
                return priceA >= priceB ? shipB : shipA;
            }

            case SuccessResult when resultB is not SuccessResult:
                return shipA;
        }

        if (resultA is not SuccessResult && resultB is SuccessResult)
        {
            return shipB;
        }

        return null;
    }
}