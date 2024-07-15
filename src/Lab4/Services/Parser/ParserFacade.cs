using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

public class ParserFacade
{
    private readonly string _line;
    private CommandNameParser? _nameParser;
    private ParametersParser? _parametersParser;
    private FlagsParser? _flagsParser;

    public ParserFacade(string line)
    {
        _line = line;
    }

    public void SetCommandNameParser(CommandNameParser parser)
    {
        _nameParser = parser;
    }

    public void SetParametersParser(ParametersParser parser)
    {
        _parametersParser = parser;
        _nameParser?.SetNext(_parametersParser);
    }

    public void SetFlagsParser(FlagsParser parser)
    {
        _flagsParser = parser;
        _parametersParser?.SetNext(_flagsParser);
    }

    public ParseResult Parse()
    {
        _nameParser?.Parse(_line);
        if (_nameParser == null)
        {
            throw new ArgumentNullException(nameof(_nameParser));
        }

        if (_parametersParser == null)
        {
            throw new ArgumentNullException(nameof(_parametersParser));
        }

        if (_flagsParser == null)
        {
            throw new ArgumentNullException(nameof(_flagsParser));
        }

        return new ParseResult(_nameParser.CommandName, _parametersParser.Parameters, _flagsParser.Flags);
    }
}