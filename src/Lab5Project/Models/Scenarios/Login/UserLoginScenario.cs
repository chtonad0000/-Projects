using Lab5Project.Models.OperatingMods.UserMode;
using Lab5Project.Models.Scenarios.Mode;
using Spectre.Console;

namespace Lab5Project.Models.Scenarios.Login;

public class UserLoginScenario : IScenario
{
    private readonly IUserMode _userMode;

    public UserLoginScenario(IUserMode userMode)
    {
        _userMode = userMode;
    }

    public string Name => "Login as user";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter your bank number");
        int pin = AnsiConsole.Ask<int>("Enter pin");
        LoginResult.LoginResult result = _userMode.Login(number, pin);
        if (result is LoginResult.LoginResult.SuccessResult)
        {
            AnsiConsole.Clear();
            new UserModeScenario(_userMode).Run();
        }
        else
        {
            AnsiConsole.Ask<string>("Incorrect number or pin");
            Run();
        }
    }
}