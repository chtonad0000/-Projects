using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly IFolder _folder;

    public TreeGoToCommand(IFolder folder, WorkingDirectory workingDirectory)
    {
        _folder = folder;
        WorkingDirectory = workingDirectory;
    }

    public WorkingDirectory WorkingDirectory { get; private set; }

    public void Use()
    {
        WorkingDirectory.RelativeFolder = _folder;
    }
}