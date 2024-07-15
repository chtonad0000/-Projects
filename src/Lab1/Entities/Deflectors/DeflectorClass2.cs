namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorClass2 : DeflectorBase
{
    private const int Deflector2HealthPoints = 180;
    private const int MeteoriteDamageToDeflector = 60;
    private const int SmallAsteroidDamageToDeflector = 18;
    private const int SpaceWhaleDamageToDeflector = 190;
    private const int AntimatterDamageToDeflector = 0;

    public DeflectorClass2(AntimatterDeflectorBase? antimatterModification)
        : base(Deflector2HealthPoints, antimatterModification)
    {
        AntimatterModification = antimatterModification;
        AntimatterModification = antimatterModification;
        MeteoriteDamage = MeteoriteDamageToDeflector;
        SmallAsteroidDamage = SmallAsteroidDamageToDeflector;
        SpaceWhaleDamage = SpaceWhaleDamageToDeflector;
        AntimatterDamage = AntimatterDamageToDeflector;
    }
}