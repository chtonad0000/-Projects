namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

public class ArmorClass1 : ArmorBase
{
    private const int Armor1HitPoints = 61;
    private const int MeteoriteDamageToArmor = 61;
    private const int AsteroidDamageToArmor = 60;
    private const int SpaceWhaleDamageToArmor = 61;
    private const int AntimatterDamageToArmor = 0;

    public ArmorClass1()
        : base(Armor1HitPoints)
    {
        MeteoriteDamage = MeteoriteDamageToArmor;
        SmallAsteroidDamage = AsteroidDamageToArmor;
        SpaceWhaleDamage = SpaceWhaleDamageToArmor;
        AntimatterDamage = AntimatterDamageToArmor;
    }
}