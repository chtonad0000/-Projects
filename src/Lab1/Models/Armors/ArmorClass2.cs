namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

public class ArmorClass2 : ArmorBase
{
    private const int Armor1HitPoints = 201;
    private const int MeteoriteDamageToArmor = 100;
    private const int AsteroidDamageToArmor = 40;
    private const int SpaceWhaleDamageToArmor = 201;
    private const int AntimatterDamageToArmor = 0;

    public ArmorClass2()
        : base(Armor1HitPoints)
    {
        MeteoriteDamage = MeteoriteDamageToArmor;
        SmallAsteroidDamage = AsteroidDamageToArmor;
        SpaceWhaleDamage = SpaceWhaleDamageToArmor;
        AntimatterDamage = AntimatterDamageToArmor;
    }
}