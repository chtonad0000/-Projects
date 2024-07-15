using Lab5Project.Entities;

namespace Lab5Project.Services.Infrastructure.Repositories.Interfaces;

public interface IBankAccountsRepository
{
    public Task<BankAccount?> GetBankAccount(int number, int pin);
    public void Update(int number, int amount);

    public Task<BankAccount?> AddAccount(int number, int pin);
}