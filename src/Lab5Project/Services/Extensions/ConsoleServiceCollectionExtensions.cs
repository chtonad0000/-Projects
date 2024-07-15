using Lab5Project.Models.Scenarios;
using Lab5Project.Models.Scenarios.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5Project.Services.Extensions;

public static class ConsoleServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<StartScenario>();

        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();

        return collection;
    }
}