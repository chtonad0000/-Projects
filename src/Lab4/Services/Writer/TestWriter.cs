namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

public class TestWriter : IWriter
{
    public int Counter { get; private set; }
    public void Write(string text)
    {
        Counter++;
    }
}