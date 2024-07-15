using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public class ConnectExecutor : BaseExecutor
{
    public ConnectExecutor(CommandFacade facade)
        : base(facade)
    {
    }

    public override void ExecuteCommand(Collection<string> parameters, Collection<string> flags)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        string? connectMode =
            flags.FirstOrDefault(flag => flag.StartsWith("-m", StringComparison.OrdinalIgnoreCase));
        if (connectMode == null)
        {
            throw new ArgumentException("no mode flag");
        }

        Facade.Connect(parameters[0], connectMode[3..]);
    }
}