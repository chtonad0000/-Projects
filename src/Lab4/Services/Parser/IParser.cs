namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public interface IParser
{
    public void SetNext(IParser parser);
    public void Parse(string str);
}