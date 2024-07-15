using Itmo.ObjectOrientedProgramming.Lab4.Services.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ConnectCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public IFileSystemStrategy? FileSystem { get; private set; }

    public void Use()
    {
        switch (_mode)
        {
            case "local":
                FileSystem = new LocalFileSystemStrategy(_path);
                break;
            case "in-memory":
                FileSystem = new InMemoryFileSystemStrategy(_path);
                break;
        }
    }
}