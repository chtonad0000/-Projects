using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Paths;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class PathCheckService
{
    public static ResultBase PathComplete(Path? path, Ship? ship)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        int time = 0;
        int impulseFuel = ship.Engine.EngineFuelAmount;
        ship.StartEngines();
        int jumpFuel = 0;
        if (ship.EngineJump != null)
        {
            jumpFuel = ship.EngineJump.FuelAmount;
        }

        foreach (PathSegment segment in path.Segments)
        {
            switch (segment.Environment)
            {
                case Space:
                {
                    foreach (ObstacleBase obstacle in segment.Environment.Obstacles)
                    {
                        ship.TakeDamage(obstacle);
                    }

                    ship.Engine.FuelWaste(segment.Distance);
                    if (!ship.Engine.HasFuel)
                    {
                        return new ShipLostResult();
                    }

                    time += segment.Distance / ship.Engine.EngineSpeed;
                    break;
                }

                case NebulaeDensity nebulaeDensity when nebulaeDensity.CanalRanges != null:
                {
                    if (ship.EngineJump == null)
                    {
                        return new ShipLostResult();
                    }

                    foreach (Canal canal in nebulaeDensity.CanalRanges)
                    {
                        if (ship.EngineJump.RangeDistance < canal.Distance)
                        {
                            return new ShipLostResult();
                        }

                        for (int i = 0; i < canal.CountAntimatterFlashes; ++i)
                        {
                            ship.TakeDamage(new Antimatter());
                        }

                        ship.EngineJump.FuelWaste(canal.Distance);
                        if (!ship.EngineJump.HasFuel)
                        {
                            return new ShipLostResult();
                        }

                        time += 1;
                    }

                    break;
                }

                case NebulaeNitrine when ship.Engine is EngineC:
                    return new ShipLostResult();
                case NebulaeNitrine:
                {
                    if (ship.NitrineEmitter == null)
                    {
                        foreach (ObstacleBase obstacleBase in segment.Environment.Obstacles)
                        {
                            var whale = (SpaceWhale)obstacleBase;
                            for (int i = 0; i < whale.Population; ++i)
                            {
                                ship.TakeDamage(whale);
                            }
                        }
                    }

                    ship.Engine.FuelWaste(segment.Distance);
                    if (!ship.Engine.HasFuel)
                    {
                        return new ShipLostResult();
                    }

                    time += segment.Distance / ship.Engine.EngineSpeed;
                    break;
                }
            }
        }

        if (!ship.CrewIsAlive)
        {
            return new CrewDiedResult();
        }

        if (!ship.Armor.IsAlive)
        {
            return new ShipDestroyedResult();
        }

        impulseFuel -= ship.Engine.EngineFuelAmount;
        if (ship.EngineJump != null)
        {
            jumpFuel -= ship.EngineJump.FuelAmount;
        }

        return new SuccessResult(time, impulseFuel, jumpFuel);
    }
}