using Lab5Project.Models.OperatingMods.AdminMode;
using Spectre.Console;

namespace Lab5Project.Models.Scenarios.Mode;

public class AdminModeScenario : IScenario
{
    private readonly IAdminMode _adminMode;

    public AdminModeScenario(IAdminMode adminMode)
    {
        _adminMode = adminMode;
    }

    public string Name => "Admin mode";

    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("Enter account number to look about its history");
        AnsiConsole.WriteLine(_adminMode.GetAccountHistory(accountNumber));
        SelectionPrompt<string> selector = new SelectionPrompt<string>()
            .Title("Select action")
            .AddChoices("Another account")
            .AddChoices("Logout");
        string choice = AnsiConsole.Prompt(selector);
        if (choice == "Another account")
        {
            AnsiConsole.Clear();
            Run();
        }
        else if (choice == "Logout")
        {
            _adminMode.Logout();
        }
    }
}