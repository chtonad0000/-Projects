using Lab5Project.Models.OperatingMods.RegistrationMode;
using Spectre.Console;

namespace Lab5Project.Models.Scenarios;

public class RegistrationScenario : IScenario
{
    private readonly IRegistrationMode _registrationMode;

    public RegistrationScenario(IRegistrationMode registrationMode)
    {
        _registrationMode = registrationMode;
    }

    public string Name => "Registration";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter bank number");
        int pin = AnsiConsole.Ask<int>("Enter pin");
        int pin2 = AnsiConsole.Ask<int>("Repeat pin");
        if (pin != pin2)
        {
            AnsiConsole.WriteLine("Pins don't match");
            Run();
        }
        else
        {
            RegistrationResult.RegistrationResult result = _registrationMode.Register(number, pin);
            if (result is RegistrationResult.RegistrationResult.RegistrationSuccess)
            {
                AnsiConsole.Ask<string>("Registration complete");
            }
            else
            {
                AnsiConsole.Ask<string>("Account with that number already exists");
                Run();
            }
        }
    }
}