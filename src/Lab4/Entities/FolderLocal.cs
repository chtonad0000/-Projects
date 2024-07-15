using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FolderLocal : IFolder
{
    public FolderLocal(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new ArgumentException("directory doesn't exists");
        }

        Path = path;
        Name = System.IO.Path.GetFileName(path);
    }

    public string Name { get; private set; }
    public string Path { get; }
}