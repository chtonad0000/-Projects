using System.Diagnostics.CodeAnalysis;
using Lab5Project.Models.OperatingMods.UserMode;

namespace Lab5Project.Models.Scenarios.Login;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserMode _mode;

    public UserLoginScenarioProvider(
        IUserMode mode)
    {
        _mode = mode;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_mode.CurrentAccount is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(_mode);
        return true;
    }
}