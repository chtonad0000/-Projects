using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TreeTraversal;

public class InMemorySystemTraversal : ITraversal
{
    private readonly InMemoryFileSystemStrategy _fileSystem;
    public InMemorySystemTraversal(InMemoryFileSystemStrategy fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public Tree MakeTraversal()
    {
        var root = new TreeFolder(_fileSystem.AbsoluteFolder.Name);
        AddComponents(root, _fileSystem.AbsoluteFolder);

        return new Tree(root);
    }

    private void AddComponents(TreeFolder folder, FolderInMemory addFolder)
    {
        foreach (IFileSystemComponent component in addFolder.Components)
        {
            if (component is FileInMemory file)
            {
                folder.Components.Add(new TreeFile(file.Name, file.Text));
            }

            if (component is FolderInMemory folderInMemory)
            {
                var newFolder = new TreeFolder(folderInMemory.Name);
                AddComponents(newFolder, folderInMemory);
                folder.Components.Add(newFolder);
            }
        }
    }
}