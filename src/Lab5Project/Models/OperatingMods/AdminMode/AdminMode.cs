using Lab5Project.Services.Infrastructure.Repositories.Interfaces;

namespace Lab5Project.Models.OperatingMods.AdminMode;

public class AdminMode : IAdminMode
{
    private readonly IHistoryRepository _repository;
    private readonly IAdminRepository _adminRepository;

    public AdminMode(IHistoryRepository repository, IAdminRepository adminRepository)
    {
        _repository = repository;
        _adminRepository = adminRepository;
    }

    public bool InSystem { get; private set; }
    public LoginResult.LoginResult Login(string password)
    {
        if (_adminRepository.TryPassword(password).Result)
        {
            InSystem = true;
            return LoginResult.LoginResult.SuccessResult;
        }

        return LoginResult.LoginResult.FailResult;
    }

    public void Logout()
    {
        InSystem = false;
    }

    public string GetAccountHistory(int number)
    {
        return _repository.GetAccountHistory(number).Result;
    }
}