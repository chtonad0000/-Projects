namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerBlock : IComponent<PowerBlock>
{
    public PowerBlock(string name, int maxPower)
    {
        Name = name;
        MaxPower = maxPower;
    }

    public string Name { get; private set; }
    public int MaxPower { get; private set; }

    public PowerBlock Clone()
    {
        return new PowerBlock(Name, MaxPower);
    }
}