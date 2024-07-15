using Lab5Project.Models.OperatingMods.AdminMode;
using Lab5Project.Models.OperatingMods.RegistrationMode;
using Lab5Project.Models.OperatingMods.UserMode;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5Project.Services.Extensions;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserMode, UserMode>();
        collection.AddScoped<IAdminMode, AdminMode>();
        collection.AddScoped<IRegistrationMode, RegistrationMode>();

        return collection;
    }
}