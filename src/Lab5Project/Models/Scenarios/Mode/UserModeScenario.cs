using Lab5Project.Entities;
using Lab5Project.Models.OperatingMods.UserMode;
using Spectre.Console;

namespace Lab5Project.Models.Scenarios.Mode;

public class UserModeScenario : IScenario
{
    private readonly IUserMode _userMode;

    public UserModeScenario(IUserMode userMode)
    {
        _userMode = userMode;
    }

    public string Name => "User mode";

    public void Run()
    {
        AnsiConsole.WriteLine("Your current balance: " + _userMode.CurrentAccount?.MoneyAmount);
        SelectionPrompt<string> selector = new SelectionPrompt<string>()
            .Title("Select action")
            .AddChoices("Put money")
            .AddChoices("Withdraw money")
            .AddChoices("Log out");
        string action = AnsiConsole.Prompt(selector);
        if (action == "Put money")
        {
            int amount = AnsiConsole.Ask<int>("How much money do you want to put?");
            _userMode.CurrentAccount?.PutMoney(amount);
            _userMode.Update();
            _userMode.Log(OperationType.Put, amount);
            Run();
        }
        else if (action == "Withdraw money")
        {
            int amount = AnsiConsole.Ask<int>("How much money do you want to withdraw?");
            _userMode.CurrentAccount?.WithdrawMoney(amount);
            _userMode.Update();
            _userMode.Log(OperationType.Withdraw, amount);
            Run();
        }
        else if (action == "Log out")
        {
            _userMode.Logout();
        }
    }
}