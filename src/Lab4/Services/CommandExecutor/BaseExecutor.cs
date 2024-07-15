using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public abstract class BaseExecutor
{
    protected BaseExecutor(CommandFacade facade)
    {
        Facade = facade;
    }

    protected CommandFacade Facade { get; }

    public abstract void ExecuteCommand(Collection<string> parameters, Collection<string> flags);
}