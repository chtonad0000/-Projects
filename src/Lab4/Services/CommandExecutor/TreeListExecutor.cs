using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public class TreeListExecutor : BaseExecutor
{
    public TreeListExecutor(CommandFacade facade)
        : base(facade)
    {
    }

    public override void ExecuteCommand(Collection<string> parameters, Collection<string> flags)
    {
        string? listMode =
            flags.FirstOrDefault(flag => flag.StartsWith("-m", StringComparison.OrdinalIgnoreCase));
        if (listMode == null)
        {
            throw new ArgumentException("no mode flag");
        }

        string? listDepth =
            flags.FirstOrDefault(flag => flag.StartsWith("-d", StringComparison.OrdinalIgnoreCase));
        if (listDepth == null)
        {
            throw new ArgumentException("no depth flag");
        }

        Facade.TreeList(int.Parse(listDepth[3..], CultureInfo.InvariantCulture), listMode[3..]);
    }
}