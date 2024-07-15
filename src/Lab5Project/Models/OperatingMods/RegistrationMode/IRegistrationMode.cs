namespace Lab5Project.Models.OperatingMods.RegistrationMode;

public interface IRegistrationMode
{
    public RegistrationResult.RegistrationResult Register(int number, int pin);
}