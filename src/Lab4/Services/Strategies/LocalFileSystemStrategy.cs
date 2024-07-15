using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TreeTraversal;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

public class LocalFileSystemStrategy : IFileSystemStrategy
{
    public LocalFileSystemStrategy(string path)
    {
        AbsolutePath = path;
    }

    public string AbsolutePath { get; private set; }

    public IFile ReturnFile(string path, string name)
    {
        return new FileLocal(path, name);
    }

    public IFolder ReturnFolder(string path)
    {
        return new FolderLocal(path);
    }

    public void Show(int depth, IWriter writer)
    {
        if (writer == null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        if (depth <= 0)
        {
            throw new ArgumentException("depth must be positive");
        }

        var traversal = new LocalSystemTraversal(this);
        var visualizer = new TreeVisualizing("+", "-");
        visualizer.Visualize(depth, visualizer.Indent, traversal.MakeTraversal().Root);
        writer.Write(visualizer.Result);
    }
}