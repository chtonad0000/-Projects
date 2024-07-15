using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        string? input;
        var facade = new CommandFacade();
        var exe = new CommandExecutor();
        var commandNames = new Collection<string>
        {
            "connect", "disconnect", "tree goto", "tree list", "file show", "file move", "file copy", "file delete",
            "file rename",
        };
        exe.AddExecutor("connect", new ConnectExecutor(facade));
        exe.AddExecutor("disconnect", new DisconnectExecutor(facade));
        exe.AddExecutor("tree goto", new TreeGotoExecutor(facade));
        exe.AddExecutor("tree list", new TreeListExecutor(facade));
        exe.AddExecutor("file show", new FileShowExecutor(facade));
        exe.AddExecutor("file move", new FileMoveExecutor(facade));
        exe.AddExecutor("file copy", new FileCopyExecutor(facade));
        exe.AddExecutor("file delete", new FileDeleteExecutor(facade));
        exe.AddExecutor("file rename", new FileRenameExecutor(facade));
        while ((input = Console.ReadLine()) != "end" && input is not null)
        {
            var parser = new ParserFacade(input);
            parser.SetCommandNameParser(new CommandNameParser(commandNames));
            parser.SetParametersParser(new ParametersParser(" "));
            parser.SetFlagsParser(new FlagsParser(" "));
            exe.Execute(parser.Parse());
        }
    }
}