using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly IFile _file;

    public FileDeleteCommand(IFile file)
    {
        _file = file;
    }

    public void Use()
    {
        _file.Delete();
    }
}