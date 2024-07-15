using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;

public class CommandExecutor
{
    private readonly Dictionary<string, BaseExecutor> _executors = new();

    public void AddExecutor(string name, BaseExecutor executor)
    {
        _executors.Add(name, executor);
    }

    public void Execute(ParseResult result)
    {
        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        _executors[result.CommandName].ExecuteCommand(result.Parameters, result.Flags);
    }
}