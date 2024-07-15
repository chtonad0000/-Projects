using System.Diagnostics.CodeAnalysis;
using Lab5Project.Models.OperatingMods.AdminMode;

namespace Lab5Project.Models.Scenarios.Login;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminMode _mode;

    public AdminLoginScenarioProvider(IAdminMode mode)
    {
        _mode = mode;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_mode.InSystem)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_mode);
        return true;
    }
}