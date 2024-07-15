using Spectre.Console;

namespace Lab5Project.Models.Scenarios;

public class StartScenario : IScenario
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public StartScenario(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public string Name => "Start";

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select mode")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario mode = AnsiConsole.Prompt(selector);
        mode.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}