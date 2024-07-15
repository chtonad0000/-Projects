namespace Lab5Project.Models.OperatingMods.AdminMode;

public interface IAdminMode
{
    public bool InSystem { get; }
    public LoginResult.LoginResult Login(string password);
    public void Logout();
    public string GetAccountHistory(int number);
}