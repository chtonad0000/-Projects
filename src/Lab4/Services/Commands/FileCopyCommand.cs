using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileCopyCommand : ICommand
{
    private readonly IFile _file;
    private readonly IFolder _folder;

    public FileCopyCommand(IFile file, IFolder folder)
    {
        _file = file;
        _folder = folder;
    }

    public void Use()
    {
        _file.Copy(_folder);
    }
}