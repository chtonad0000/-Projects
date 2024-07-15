using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ParametersParser : ParserBase
{
    private readonly string _separator;

    public ParametersParser(string separator)
    {
        _separator = separator;
    }

    public Collection<string> Parameters { get; private set; } = new();

    public override void Parse(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        string[] arguments = str.Split(_separator);
        foreach (string argument in arguments)
        {
            if (!argument.StartsWith('-'))
            {
                Parameters.Add(argument);
            }
        }

        Next?.Parse(str);
    }
}