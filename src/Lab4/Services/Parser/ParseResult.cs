using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ParseResult
{
    public ParseResult(string commandName, Collection<string> parameters, Collection<string> flags)
    {
        CommandName = commandName;
        Parameters = parameters;
        Flags = flags;
    }

    public string CommandName { get; }
    public Collection<string> Parameters { get; }
    public Collection<string> Flags { get; }
}