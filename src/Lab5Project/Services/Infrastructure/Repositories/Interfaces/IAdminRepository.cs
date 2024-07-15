namespace Lab5Project.Services.Infrastructure.Repositories.Interfaces;

public interface IAdminRepository
{
    public Task<bool> TryPassword(string password);
}