using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5Project.Entities;
using Npgsql;

namespace Lab5Project.Services.Infrastructure.Plugin;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.MapEnum<OperationType>();
    }
}