namespace Lab5Project.Models.Scenarios;

public interface IScenario
{
    public string Name { get; }

    public void Run();
}