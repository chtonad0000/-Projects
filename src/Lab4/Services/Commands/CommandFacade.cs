using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class CommandFacade
{
    private IFileSystemStrategy? _fileSystemStrategy;
    public WorkingDirectory WorkingDirectory { get; private set; } = new();

    public void Connect(string address, string mode)
    {
        var connect = new ConnectCommand(address, mode);
        connect.Use();
        if (connect.FileSystem == null)
        {
            throw new ArgumentException("No directory with that path", address);
        }

        _fileSystemStrategy = connect.FileSystem;
        WorkingDirectory = new WorkingDirectory
        {
            RelativeFolder = _fileSystemStrategy.ReturnFolder(address),
        };
    }

    public void Disconnect()
    {
        var disconnect = new DisconnectCommand();
        disconnect.Use();
        _fileSystemStrategy = disconnect.FileSystem;
    }

    public void TreeGoto(string path)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (path == null)
        {
            throw new ArgumentException("path can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            path = Path.Combine(WorkingDirectory.RelativeFolder.Path, path);
        }

        if (!path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("path not in the connected directory");
        }

        var treeGoTo = new TreeGoToCommand(_fileSystemStrategy.ReturnFolder(path), WorkingDirectory);
        treeGoTo.Use();
        WorkingDirectory = treeGoTo.WorkingDirectory;
    }

    public void TreeList(int depth, string mode)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        IWriter? writer = null;
        switch (mode)
        {
            case "console":
                writer = new ConsoleWriter();
                break;
            case "test":
                writer = new TestWriter();
                break;
        }

        if (writer == null)
        {
            throw new ArgumentException("writer is not initialized");
        }

        var treeList = new TreeListCommand(depth, _fileSystemStrategy, writer);
        treeList.Use();
    }

    public void FileShow(string path, string mode)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (path == null)
        {
            throw new ArgumentException("path can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            path = Path.Combine(WorkingDirectory.RelativeFolder.Path, path);
        }

        if (!path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("path not in the connected directory");
        }

        switch (mode)
        {
            case "console":
                var showCommand =
                    new FileShowCommand(_fileSystemStrategy.ReturnFile(path, Path.GetFileName(path)), new ConsoleWriter());
                showCommand.Use();
                break;
            case "test":
                var showCommandTest =
                    new FileShowCommand(_fileSystemStrategy.ReturnFile(path, Path.GetFileName(path)), new TestWriter());
                showCommandTest.Use();
                break;
        }
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (sourcePath == null)
        {
            throw new ArgumentException("source path can't be null");
        }

        if (destinationPath == null)
        {
            throw new ArgumentException("destination can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !sourcePath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            sourcePath = Path.Combine(WorkingDirectory.RelativeFolder.Path, sourcePath);
        }

        if (WorkingDirectory.RelativeFolder != null && !destinationPath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            destinationPath = Path.Combine(WorkingDirectory.RelativeFolder.Path, destinationPath);
        }

        if (!sourcePath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("source path not in the connected directory");
        }

        if (!destinationPath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("destination path not in the connected directory");
        }

        var move =
            new FileMoveCommand(_fileSystemStrategy.ReturnFile(sourcePath, Path.GetFileName(sourcePath)), _fileSystemStrategy.ReturnFolder(destinationPath));
        move.Use();
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (sourcePath == null)
        {
            throw new ArgumentException("source path can't be null");
        }

        if (destinationPath == null)
        {
            throw new ArgumentException("destination path can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !sourcePath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            sourcePath = Path.Combine(WorkingDirectory.RelativeFolder.Path, sourcePath);
        }

        if (WorkingDirectory.RelativeFolder != null && !destinationPath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            destinationPath = Path.Combine(WorkingDirectory.RelativeFolder.Path, destinationPath);
        }

        if (!sourcePath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("source path not in the connected directory");
        }

        if (!destinationPath.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("destination path not in the connected directory");
        }

        var move =
            new FileCopyCommand(_fileSystemStrategy.ReturnFile(sourcePath, Path.GetFileName(sourcePath)), _fileSystemStrategy.ReturnFolder(destinationPath));
        move.Use();
    }

    public void FileDelete(string path)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (path == null)
        {
            throw new ArgumentException("path can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            path = Path.Combine(WorkingDirectory.RelativeFolder.Path, path);
        }

        if (!path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("path not in the connected directory");
        }

        var delete =
            new FileDeleteCommand(_fileSystemStrategy.ReturnFile(path, Path.GetFileName(path)));
        delete.Use();
    }

    public void FileRename(string path, string name)
    {
        if (_fileSystemStrategy == null)
        {
            throw new ArgumentException("You haven't connect Directory");
        }

        if (path == null)
        {
            throw new ArgumentException("path can't be null");
        }

        if (WorkingDirectory.RelativeFolder != null && !path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            path = Path.Combine(WorkingDirectory.RelativeFolder.Path, path);
        }

        if (!path.StartsWith(_fileSystemStrategy.AbsolutePath, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("path not in the connected directory");
        }

        var rename = new FileRenameCommand(_fileSystemStrategy.ReturnFile(path, Path.GetFileName(path)), name);
        rename.Use();
    }
}