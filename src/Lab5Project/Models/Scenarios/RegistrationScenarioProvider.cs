using System.Diagnostics.CodeAnalysis;
using Lab5Project.Models.OperatingMods.RegistrationMode;

namespace Lab5Project.Models.Scenarios;

public class RegistrationScenarioProvider : IScenarioProvider
{
    private readonly IRegistrationMode _mode;

    public RegistrationScenarioProvider(IRegistrationMode mode)
    {
        _mode = mode;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new RegistrationScenario(_mode);
        return true;
    }
}