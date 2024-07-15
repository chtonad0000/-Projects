using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileMoveCommand : ICommand
{
    private readonly IFile _file;
    private readonly IFolder _folder;
    public FileMoveCommand(IFile file, IFolder folder)
    {
        _file = file;
        _folder = folder;
    }

    public void Use()
    {
        _file.Move(_folder);
    }
}