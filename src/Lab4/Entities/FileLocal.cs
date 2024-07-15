using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FileLocal : IFile
{
    public FileLocal(string path, string name)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException("file doesn't exists");
        }

        Path = path;
        Name = name;
        Text = File.ReadAllText(Path);
    }

    public string Name { get; private set; }

    public string Path { get; private set; }
    public string Text { get; }

    public void Rename(string newName)
    {
        string? directory = System.IO.Path.GetDirectoryName(Path);
        if (directory == null)
        {
            throw new ArgumentException("FIle doesn't have directory");
        }

        string newPath = System.IO.Path.Combine(directory, newName);
        if (File.Exists(newPath))
        {
            throw new ArgumentException("File with that name already exists");
        }

        File.Move(Path, newPath);
        Path = newPath;
    }

    public void Copy(IFolder folder)
    {
        if (folder == null)
        {
            throw new ArgumentNullException(nameof(folder));
        }

        if (folder is not FolderLocal)
        {
            throw new ArgumentException("folder must be local", nameof(folder));
        }

        string newPath = System.IO.Path.Combine(folder.Path, Name);
        if (File.Exists(newPath))
        {
            throw new ArgumentException("File with same name exists in new directory");
        }

        File.Copy(Path, newPath);
    }

    public void Delete()
    {
        File.Delete(Path);
    }

    public void Move(IFolder folder)
    {
        if (folder == null)
        {
            throw new ArgumentNullException(nameof(folder));
        }

        if (folder is not FolderLocal)
        {
            throw new ArgumentException("folder must be local", nameof(folder));
        }

        string newPath = System.IO.Path.Combine(folder.Path, Name);
        if (File.Exists(newPath))
        {
            throw new ArgumentException("File with same name exists in new directory");
        }

        File.Move(Path, newPath);
    }
}