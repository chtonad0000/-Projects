namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public abstract class ParserBase : IParser
{
    protected IParser? Next { get; private set; }

    public void SetNext(IParser parser)
    {
        Next = parser;
    }

    public abstract void Parse(string str);
}