using Lab5Project.Entities;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;

namespace Lab5Project.Models.OperatingMods.RegistrationMode;

public class RegistrationMode : IRegistrationMode
{
    private readonly IBankAccountsRepository _bankAccountsRepository;

    public RegistrationMode(IBankAccountsRepository bankAccountsRepository)
    {
        _bankAccountsRepository = bankAccountsRepository;
    }

    public RegistrationResult.RegistrationResult Register(int number, int pin)
    {
        Task<BankAccount?> account = _bankAccountsRepository.AddAccount(number, pin);
        if (account.Result is null)
        {
            return RegistrationResult.RegistrationResult.RegistrationFail;
        }

        return RegistrationResult.RegistrationResult.RegistrationSuccess;
    }
}