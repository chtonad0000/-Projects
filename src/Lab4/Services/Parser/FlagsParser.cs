using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class FlagsParser : ParserBase
{
    private readonly string _separator;

    public FlagsParser(string separator)
    {
        _separator = separator;
    }

    public Collection<string> Flags { get; private set; } = new();

    public override void Parse(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        string[] arguments = str.Split(_separator);
        for (int i = 0; i < arguments.Length - 1; ++i)
        {
            if (arguments[i].StartsWith('-'))
            {
                Flags.Add(arguments[i] + ' ' + arguments[i + 1]);
            }
        }

        Next?.Parse(str);
    }
}