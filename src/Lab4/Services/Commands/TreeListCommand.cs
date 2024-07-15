using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly IWriter _writer;
    private readonly IFileSystemStrategy _fileSystem;

    public TreeListCommand(int depth, IFileSystemStrategy fileSystem, IWriter writer)
    {
        _depth = depth;
        _fileSystem = fileSystem;
        _writer = writer;
    }

    public void Use()
    {
        _fileSystem.Show(_depth, _writer);
    }
}