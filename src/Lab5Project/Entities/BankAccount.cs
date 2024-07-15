namespace Lab5Project.Entities;

public class BankAccount
{
    public BankAccount(int moneyAmount, int number)
    {
        MoneyAmount = moneyAmount;
        Number = number;
    }

    public int Number { get; private set; }

    public int MoneyAmount { get; private set; }

    public void WithdrawMoney(int amount)
    {
        if (amount > MoneyAmount)
        {
            throw new ArgumentException("not enough money on account");
        }

        MoneyAmount -= amount;
    }

    public void PutMoney(int amount)
    {
        MoneyAmount += amount;
    }
}