namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Size
{
    public Size(double length, double height)
    {
        Length = length;
        Height = height;
    }

    public double Length { get; private set; }
    public double Height { get; private set; }
}