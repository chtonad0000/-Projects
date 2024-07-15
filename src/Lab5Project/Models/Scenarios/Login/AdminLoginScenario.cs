using Lab5Project.Models.OperatingMods.AdminMode;
using Lab5Project.Models.Scenarios.Mode;
using Spectre.Console;

namespace Lab5Project.Models.Scenarios.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminMode _adminMode;

    public AdminLoginScenario(IAdminMode adminMode)
    {
        _adminMode = adminMode;
    }

    public string Name => "Login as administrator";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter system password");
        LoginResult.LoginResult result = _adminMode.Login(password);
        if (result is LoginResult.LoginResult.SuccessResult)
        {
            AnsiConsole.Clear();
            new AdminModeScenario(_adminMode).Run();
        }
        else
        {
            throw new ArgumentException("Incorrect password");
        }
    }
}