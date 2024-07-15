using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public class DisconnectExecutor : BaseExecutor
{
    public DisconnectExecutor(CommandFacade facade)
    : base(facade)
    {
    }

    public override void ExecuteCommand(Collection<string> parameters, Collection<string> flags)
    {
        Facade.Disconnect();
    }
}