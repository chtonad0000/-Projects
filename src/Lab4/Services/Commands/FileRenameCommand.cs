using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRenameCommand : ICommand
{
    private readonly IFile _file;
    private readonly string _name;

    public FileRenameCommand(IFile file, string name)
    {
        _file = file;
        _name = name;
    }

    public void Use()
    {
        _file.Rename(_name);
    }
}