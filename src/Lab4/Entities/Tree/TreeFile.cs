namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class TreeFile : ITreeComponent
{
    public TreeFile(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public string Name { get; private set; }
    public string Text { get; private set; }
}