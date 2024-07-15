using System;
using Lab5Project.Entities;
using Lab5Project.Models.OperatingMods.UserMode;
using Lab5Project.Services.Infrastructure.Repositories.Interfaces;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MoneyTest
{
    private readonly IUserMode _userMode;

    public MoneyTest()
    {
        IBankAccountsRepository mockBankRepository = Substitute.For<IBankAccountsRepository>();
        IHistoryRepository mockHistoryRepository = Substitute.For<IHistoryRepository>();
        _userMode = new UserMode(mockBankRepository, mockHistoryRepository);
        var fakeAccount = new BankAccount(1000, 123456789);
        mockBankRepository.GetBankAccount(123456789, 1234).Returns(fakeAccount);
        _userMode.Login(123456789, 1234);
    }

    [Fact]
    public void WithdrawMoney()
    {
        _userMode.CurrentAccount?.WithdrawMoney(500);

        Assert.Equal(500, _userMode.CurrentAccount?.MoneyAmount);
    }

    [Fact]
    public void WithdrawMoneyError()
    {
        Action act = () => _userMode.CurrentAccount?.WithdrawMoney(1100);

        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void PutMoney()
    {
        _userMode.CurrentAccount?.PutMoney(500);

        Assert.Equal(1500, _userMode.CurrentAccount?.MoneyAmount);
    }
}