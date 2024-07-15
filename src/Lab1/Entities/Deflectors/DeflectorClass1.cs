namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorClass1 : DeflectorBase
{
    private const int Deflector1HealthPoints = 100;
    private const int MeteoriteDamageToDeflector = 100;
    private const int SmallAsteroidDamageToDeflector = 50;
    private const int SpaceWhaleDamageToDeflector = 110;
    private const int AntimatterDamageToDeflector = 0;
    public DeflectorClass1(AntimatterDeflectorBase? antimatterModification)
        : base(Deflector1HealthPoints, antimatterModification)
    {
        AntimatterModification = antimatterModification;
        MeteoriteDamage = MeteoriteDamageToDeflector;
        SmallAsteroidDamage = SmallAsteroidDamageToDeflector;
        SpaceWhaleDamage = SpaceWhaleDamageToDeflector;
        AntimatterDamage = AntimatterDamageToDeflector;
    }
}