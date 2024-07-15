using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5Project.Entities;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;
using Npgsql;

namespace Lab5Project.Services.Infrastructure.Repositories.DataBaseRepositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<string> GetAccountHistory(int accountNumber)
    {
        const string sql = """
                           select operation, money_amount
                           from operations
                           where account_number = :accountNumber
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default)
            .ConfigureAwait(false);
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("accountNumber", accountNumber);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        string result = string.Empty;

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            string operation = reader.GetString(0);
            int moneyAmount = reader.GetInt32(1);

            result += $"Operation: {operation}, Money Amount: {moneyAmount}\n";
        }

        return result;
    }

    public async void AddHistory(int number, OperationType type, int amount)
    {
        const string sql = """
                           insert into operations
                           values (:number, :type, :amount)
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("type", type.ToString());
        command.Parameters.AddWithValue("amount", amount);
        command.ExecuteNonQuery();
    }
}