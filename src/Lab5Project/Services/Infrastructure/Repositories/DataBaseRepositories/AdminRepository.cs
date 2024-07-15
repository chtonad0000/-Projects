using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;
using Npgsql;

namespace Lab5Project.Services.Infrastructure.Repositories.DataBaseRepositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<bool> TryPassword(string password)
    {
        const string sql = """
                           select passwords
                           from admins
                           where passwords = :password;
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("password", password);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        return await reader.ReadAsync().ConfigureAwait(false);
    }
}