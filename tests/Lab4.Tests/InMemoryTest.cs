using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Services.CommandExecutor;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class InMemoryTest
{
    private readonly Collection<string> _commandNames = new()
    {
        "connect", "disconnect", "tree goto", "tree list", "file show", "file move", "file copy", "file delete",
        "file rename",
    };

    private CommandFacade _facade = new();
    private CommandExecutor _exe = new();

    [Fact]
    public void ConnectTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
    }

    [Fact]
    public void DisconnectTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "disconnect";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("disconnect", result2.CommandName);
    }

    [Fact]
    public void TreeGotoTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "tree goto folder";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("tree goto", result2.CommandName);
        Assert.Equal("folder", result2.Parameters[0]);
    }

    [Fact]
    public void TreeListTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "tree list -d 2 -m test";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("tree list", result2.CommandName);
        Assert.Equal("-d 2", result2.Flags[0]);
        Assert.Equal("-m test", result2.Flags[1]);
    }

    [Fact]
    public void FileShowTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "file show file.txt -m test";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("file show", result2.CommandName);
        Assert.Equal("file.txt", result2.Parameters[0]);
    }

    [Fact]
    public void FileMoveTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "file move file.txt folder";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("file move", result2.CommandName);
        Assert.Equal("file.txt", result2.Parameters[0]);
        Assert.Equal("folder", result2.Parameters[1]);
    }

    [Fact]
    public void FileCopyTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = "file copy file.txt folder";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("file copy", result2.CommandName);
        Assert.Equal("file.txt", result2.Parameters[0]);
        Assert.Equal("folder", result2.Parameters[1]);
    }

    [Fact]
    public void FileDeleteTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = @"file delete folder\test.txt";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("file delete", result2.CommandName);
        Assert.Equal(@"folder\test.txt", result2.Parameters[0]);
    }

    [Fact]
    public void RenameTest()
    {
        Update();
        string input = "connect IM -m in-memory";
        string input2 = @"file rename folder\test.txt rename.txt";
        var parser = new ParserFacade(input);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result = parser.Parse();
        _exe.Execute(result);
        parser = new ParserFacade(input2);
        parser.SetCommandNameParser(new CommandNameParser(_commandNames));
        parser.SetParametersParser(new ParametersParser(" "));
        parser.SetFlagsParser(new FlagsParser(" "));
        ParseResult result2 = parser.Parse();
        _exe.Execute(result2);

        Assert.Equal("connect", result.CommandName);
        Assert.Equal("IM", result.Parameters[0]);
        Assert.Equal("-m in-memory", result.Flags[0]);
        Assert.Equal("file rename", result2.CommandName);
        Assert.Equal(@"folder\test.txt", result2.Parameters[0]);
        Assert.Equal("rename.txt", result2.Parameters[1]);
    }

    private void Update()
    {
        _facade = new CommandFacade();
        _exe = new CommandExecutor();
        _exe.AddExecutor("connect", new ConnectExecutor(_facade));
        _exe.AddExecutor("disconnect", new DisconnectExecutor(_facade));
        _exe.AddExecutor("tree goto", new TreeGotoExecutor(_facade));
        _exe.AddExecutor("tree list", new TreeListExecutor(_facade));
        _exe.AddExecutor("file show", new FileShowExecutor(_facade));
        _exe.AddExecutor("file move", new FileMoveExecutor(_facade));
        _exe.AddExecutor("file copy", new FileCopyExecutor(_facade));
        _exe.AddExecutor("file delete", new FileDeleteExecutor(_facade));
        _exe.AddExecutor("file rename", new FileRenameExecutor(_facade));
    }
}