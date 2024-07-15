using System.Diagnostics.CodeAnalysis;

namespace Lab5Project.Models.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}