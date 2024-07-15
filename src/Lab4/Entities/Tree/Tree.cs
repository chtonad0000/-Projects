namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;

public class Tree
{
    public Tree(TreeFolder root)
    {
        Root = root;
    }

    public TreeFolder Root { get; private set; }
}