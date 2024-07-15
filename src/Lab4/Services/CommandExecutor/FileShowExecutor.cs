using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public class FileShowExecutor : BaseExecutor
{
    public FileShowExecutor(CommandFacade facade)
        : base(facade)
    {
    }

    public override void ExecuteCommand(Collection<string> parameters, Collection<string> flags)
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        string? showMode =
            flags.FirstOrDefault(flag => flag.StartsWith("-m", StringComparison.OrdinalIgnoreCase));
        if (showMode == null)
        {
            throw new ArgumentException("no mode flag");
        }

        Facade.FileShow(parameters[0], showMode[3..]);
    }
}