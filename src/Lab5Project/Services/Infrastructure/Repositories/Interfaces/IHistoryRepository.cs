using Lab5Project.Entities;

namespace Lab5Project.Services.Infrastructure.Repositories.Interfaces;

public interface IHistoryRepository
{
    public Task<string> GetAccountHistory(int accountNumber);
    public void AddHistory(int number, OperationType type, int amount);
}