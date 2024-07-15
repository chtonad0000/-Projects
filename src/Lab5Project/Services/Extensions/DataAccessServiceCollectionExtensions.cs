using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5Project.Services.Infrastructure.Plugin;
using Lab5Project.Services.Infrastructure.Repositories.DataBaseRepositories;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5Project.Services.Extensions;

public static class DataAccessServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IBankAccountsRepository, BankAccountRepository>();
        collection.AddScoped<IHistoryRepository, HistoryRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();

        return collection;
    }
}