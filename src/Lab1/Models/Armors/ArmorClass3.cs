namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Armors;

public class ArmorClass3 : ArmorBase
{
    private const int Armor1HitPoints = 401;
    private const int MeteoriteDamageToArmor = 80;
    private const int AsteroidDamageToArmor = 20;
    private const int SpaceWhaleDamageToArmor = 401;
    private const int AntimatterDamageToArmor = 0;

    public ArmorClass3()
        : base(Armor1HitPoints)
    {
        MeteoriteDamage = MeteoriteDamageToArmor;
        SmallAsteroidDamage = AsteroidDamageToArmor;
        SpaceWhaleDamage = SpaceWhaleDamageToArmor;
        AntimatterDamage = AntimatterDamageToArmor;
    }
}