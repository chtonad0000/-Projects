namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonicDeflector : AntimatterDeflectorBase
{
    private const int DefendCount = 3;
    public PhotonicDeflector()
        : base(DefendCount)
    {
    }
}