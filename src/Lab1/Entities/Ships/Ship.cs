using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Emitters;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class Ship
{
    protected Ship(EngineBase engine, DeflectorBase? deflector, ArmorBase armor, EngineJumpBase? engineJump, EmitterBase? nitrineEmitter)
    {
        if (engine == null)
        {
            throw new ArgumentNullException(nameof(engine));
        }

        if (armor == null)
        {
            throw new ArgumentNullException(nameof(armor));
        }

        Engine = engine;
        Deflector = deflector;
        Armor = armor;
        EngineJump = engineJump;
        CrewIsAlive = true;
        NitrineEmitter = nitrineEmitter;
    }

    public EngineBase Engine { get; private set; }

    public DeflectorBase? Deflector { get; private set; }

    public ArmorBase Armor { get; private set; }
    public EmitterBase? NitrineEmitter { get; private set; }

    public EngineJumpBase? EngineJump { get; private set; }
    public bool CrewIsAlive { get; private set; }
    public void StartEngines()
    {
        Engine.StartEngine();
    }

    public void AddModification(PhotonicDeflector photonicDeflector)
    {
        Deflector?.AddModification(photonicDeflector);
    }

    public void TakeDamage(ObstacleBase obstacle)
    {
        if (!(obstacle is SpaceWhale && NitrineEmitter != null))
        {
            if (Deflector != null && Deflector.IsOn)
            {
                if (obstacle is Antimatter && !Deflector.HasAntimatterDefend)
                {
                    CrewIsAlive = false;
                }

                Deflector.TakeDamage(obstacle);
                if (obstacle is SpaceWhale && (Deflector is not DeflectorClass3))
                {
                    Armor.TakeDamage(obstacle);
                }
            }
            else
            {
                if (obstacle is Antimatter)
                {
                    CrewIsAlive = false;
                }

                Armor.TakeDamage(obstacle);
            }
        }
    }
}