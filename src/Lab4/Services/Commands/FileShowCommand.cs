using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShowCommand : ICommand
{
    private readonly IFile _file;
    private readonly IWriter _writer;

    public FileShowCommand(IFile file, IWriter writer)
    {
        _file = file;
        _writer = writer;
    }

    public void Use()
    {
        _writer.Write(_file.Text);
    }
}