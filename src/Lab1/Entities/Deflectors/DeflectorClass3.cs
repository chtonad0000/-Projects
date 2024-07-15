namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorClass3 : DeflectorBase
{
    private const int Deflector3HealthPoints = 400;
    private const int MeteoriteDamageToDeflector = 40;
    private const int SmallAsteroidDamageToDeflector = 10;
    private const int SpaceWhaleDamageToDeflector = 400;
    private const int AntimatterDamageToDeflector = 0;

    public DeflectorClass3(AntimatterDeflectorBase? antimatterModification)
        : base(Deflector3HealthPoints, antimatterModification)
    {
        AntimatterModification = antimatterModification;
        AntimatterModification = antimatterModification;
        MeteoriteDamage = MeteoriteDamageToDeflector;
        SmallAsteroidDamage = SmallAsteroidDamageToDeflector;
        SpaceWhaleDamage = SpaceWhaleDamageToDeflector;
        AntimatterDamage = AntimatterDamageToDeflector;
    }
}