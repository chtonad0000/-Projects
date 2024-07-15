using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FolderInMemory : IFolder
{
    public FolderInMemory(string path, string name, Collection<IFileSystemComponent> components)
    {
        Path = path;
        Name = name;
        Components = components;
    }

    public string Path { get; private set; }
    public string Name { get; private set; }
    public Collection<IFileSystemComponent> Components { get; private set; }
    public FileInMemory? FindFile(string filePath)
    {
        foreach (IFileSystemComponent component in Components)
        {
            if (component is FileInMemory fileInMemory && fileInMemory.Path == filePath)
            {
                return fileInMemory;
            }

            if (component is FolderInMemory folderInMemory)
            {
                return folderInMemory.FindFile(filePath);
            }
        }

        return null;
    }

    public FolderInMemory? FindFolder(string folderPath)
    {
        if (Path == folderPath)
        {
            return this;
        }

        foreach (IFileSystemComponent component in Components)
        {
            if (component is FolderInMemory folderInMemory)
            {
                return folderInMemory.FindFolder(folderPath);
            }
        }

        return null;
    }
}