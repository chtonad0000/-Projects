using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class TreeFolder : ITreeComponent
{
    public TreeFolder(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public Collection<ITreeComponent> Components { get; private set; } = new();
}