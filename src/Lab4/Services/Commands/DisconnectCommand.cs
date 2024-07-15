using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommand
{
    public IFileSystemStrategy? FileSystem { get; private set; }

    public void Use()
    {
        FileSystem = null;
    }
}