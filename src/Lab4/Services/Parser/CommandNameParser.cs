using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class CommandNameParser : ParserBase
{
    private readonly Collection<string> _commandNames;

    public CommandNameParser(Collection<string> commandNames)
    {
        _commandNames = commandNames;
    }

    public string CommandName { get; private set; } = string.Empty;

    public override void Parse(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        string? commandName =
            _commandNames.FirstOrDefault(command => str.StartsWith(command, StringComparison.OrdinalIgnoreCase));
        if (commandName == null)
        {
            throw new ArgumentException("no command in line");
        }

        CommandName = commandName;
        if (commandName.Length < str.Length)
        {
            Next?.Parse(str[(commandName.Length + 1)..]);
        }
    }
}