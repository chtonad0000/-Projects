using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FileInMemory : IFile
{
    public FileInMemory(string path, string name, string text, FolderInMemory folderInMemory)
    {
        Path = path;
        Name = name;
        Text = text;
        Folder = folderInMemory;
    }

    public string Path { get; private set; }
    public string Name { get; private set; }

    public string Text { get; private set; }

    public FolderInMemory Folder { get; private set; }

    public void Copy(IFolder folder)
    {
        if (folder is not FolderInMemory folderInMemory)
        {
            throw new ArgumentException("folder must be in-memory", nameof(folder));
        }

        if (folderInMemory.Components.Any(component => component.Name == Name))
        {
            throw new ArgumentException("file with that name already exists");
        }

        folderInMemory.Components.Add(new FileInMemory(System.IO.Path.Combine(folderInMemory.Path, Name), Name, Text, folderInMemory));
    }

    public void Delete()
    {
        Folder.Components.Remove(this);
    }

    public void Move(IFolder folder)
    {
        Copy(folder);
        Delete();
    }

    public void Rename(string newName)
    {
        if (Folder.Components.Any(component => component.Name == newName))
        {
            throw new ArgumentException("file with that name already exists");
        }

        Name = newName;
        Path = System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(Path) ?? throw new ArgumentException("file doesn't have directory"),
            newName);
    }
}