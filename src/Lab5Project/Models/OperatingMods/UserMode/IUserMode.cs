using Lab5Project.Entities;

namespace Lab5Project.Models.OperatingMods.UserMode;

public interface IUserMode
{
    public BankAccount? CurrentAccount { get; }
    public void Logout();
    public LoginResult.LoginResult Login(int accountNumber, int pin);
    public void Update();
    public void Log(OperationType type, int amount);
}