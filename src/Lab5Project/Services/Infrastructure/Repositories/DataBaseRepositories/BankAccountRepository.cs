using System.Globalization;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5Project.Entities;
using Lab5Project.Services.Hash;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;
using Npgsql;

namespace Lab5Project.Services.Infrastructure.Repositories.DataBaseRepositories;

public class BankAccountRepository : IBankAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount?> GetBankAccount(int number, int pin)
    {
        string toHash = number.ToString(NumberFormatInfo.InvariantInfo) + pin.ToString(NumberFormatInfo.InvariantInfo);
        int hashCode = HashFunction.ComputeHash(toHash);
        const string sql = """
                           select account_number, money_amount
                           from bank_accounts
                           where hash = :hashCode;
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default).ConfigureAwait(false);
        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("hashCode", hashCode);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        return await reader.ReadAsync().ConfigureAwait(false) is false ? null : new BankAccount(reader.GetInt32(1), reader.GetInt32(0));
    }

    public async void Update(int number, int amount)
    {
        const string sql = """
                           update bank_accounts
                           set money_amount = :amount
                           where account_number = :number;
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("amount", amount);
            command.Parameters.AddWithValue("number", number);
            command.ExecuteNonQuery();
        }
    }

    public async Task<BankAccount?> AddAccount(int number, int pin)
    {
        string toHash = number.ToString(NumberFormatInfo.InvariantInfo) + pin.ToString(NumberFormatInfo.InvariantInfo);
        int hashCode = HashFunction.ComputeHash(toHash);
        const string sqlCheck = """
                                select account_number, money_amount
                                from bank_accounts
                                where account_number = :number;
                                """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);
        using (var command1 = new NpgsqlCommand(sqlCheck, connection))
        {
            command1.Parameters.AddWithValue("number", number);
            using NpgsqlDataReader reader = await command1.ExecuteReaderAsync().ConfigureAwait(false);
            if (await reader.ReadAsync().ConfigureAwait(false))
            {
                return null;
            }
        }

        const string sql = """
                           insert into bank_accounts
                           values (:hashCode, :number, 0);
                           """;
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("hashCode", hashCode);
            command.Parameters.AddWithValue("number", number);
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        return new BankAccount(0, number);
    }
}