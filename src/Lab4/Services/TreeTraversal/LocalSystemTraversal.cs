using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreeTraversal;

public class LocalSystemTraversal : ITraversal
{
    private readonly LocalFileSystemStrategy _fileSystem;

    public LocalSystemTraversal(LocalFileSystemStrategy fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public Tree MakeTraversal()
    {
        var root = new TreeFolder(_fileSystem.ReturnFolder(_fileSystem.AbsolutePath).Name);
        AddComponents(root, _fileSystem.AbsolutePath);

        return new Tree(root);
    }

    private void AddComponents(TreeFolder root, string path)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        foreach (string filePath in Directory.GetFiles(path))
        {
            root.Components.Add(new TreeFile(Path.GetFileName(filePath), File.ReadAllText(filePath)));
        }

        foreach (string folderPath in Directory.GetDirectories(path))
        {
            var folder = new TreeFolder(Path.GetFileName(folderPath));
            AddComponents(folder, folderPath);
            root.Components.Add(folder);
        }
    }
}