using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TreeTraversal;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

public class InMemoryFileSystemStrategy : IFileSystemStrategy
{
    public InMemoryFileSystemStrategy(string absolutePath)
    {
        var fol = new FolderInMemory(@"IM\folder", "folder", new Collection<IFileSystemComponent>());
        fol.Components.Add(new FileInMemory(@"IM\folder\test.txt", "test.txt", "t", fol));
        AbsoluteFolder = new FolderInMemory(@"IM", "IM", new Collection<IFileSystemComponent>());
        var file = new FileInMemory(@"IM\file.txt", "file.txt", "hello", AbsoluteFolder);
        AbsoluteFolder.Components.Add(file);
        AbsoluteFolder.Components.Add(fol);

        AbsolutePath = absolutePath;
    }

    public FolderInMemory AbsoluteFolder { get; private set; }

    public string AbsolutePath { get; }

    public IFile ReturnFile(string path, string name)
    {
        FileInMemory? file = AbsoluteFolder.FindFile(path);
        if (file == null)
        {
            throw new ArgumentException("no file with that name");
        }

        return file;
    }

    public IFolder ReturnFolder(string path)
    {
        FolderInMemory? folder = AbsoluteFolder.FindFolder(path);
        if (folder == null)
        {
            throw new ArgumentException("no folder with that name");
        }

        return folder;
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

        var traversal = new InMemorySystemTraversal(this);
        var visualizer = new TreeVisualizing("+", "-");
        visualizer.Visualize(depth, visualizer.Indent, traversal.MakeTraversal().Root);
        writer.Write(visualizer.Result);
    }
}