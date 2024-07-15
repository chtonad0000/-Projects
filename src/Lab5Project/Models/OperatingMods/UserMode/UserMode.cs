using Lab5Project.Entities;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;

namespace Lab5Project.Models.OperatingMods.UserMode;

public class UserMode : IUserMode
{
    private readonly IBankAccountsRepository _repository;
    private readonly IHistoryRepository _historyRepository;

    public UserMode(IBankAccountsRepository repository, IHistoryRepository historyRepository)
    {
        _repository = repository;
        _historyRepository = historyRepository;
    }

    public BankAccount? CurrentAccount { get; private set; }

    public void Logout()
    {
        CurrentAccount = null;
    }

    public LoginResult.LoginResult Login(int accountNumber, int pin)
    {
        Task<BankAccount?> account = _repository.GetBankAccount(accountNumber, pin);

        if (account.Result is null)
        {
            return LoginResult.LoginResult.FailResult;
        }

        CurrentAccount = account.Result;
        return LoginResult.LoginResult.SuccessResult;
    }

    public void Update()
    {
        if (CurrentAccount is null)
        {
            throw new ArgumentNullException(nameof(CurrentAccount));
        }

        _repository.Update(CurrentAccount.Number, CurrentAccount.MoneyAmount);
    }

    public void Log(OperationType type, int amount)
    {
        if (CurrentAccount is null)
        {
            throw new ArgumentException("you don't login in account");
        }

        _historyRepository.AddHistory(CurrentAccount.Number, type, amount);
    }
}