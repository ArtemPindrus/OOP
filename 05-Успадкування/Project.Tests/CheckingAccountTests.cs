namespace Project.Tests;

public class CheckingAccountTests {
    [Fact]
    public void Withdrawing_when_enough_balance_reduces_balance() {
        decimal initialBalance = 10000;
        decimal overdraftLimit = 5000;
        decimal withdraw = 14500;
        CheckingAccount sut = new(initialBalance, overdraftLimit);
        decimal expectedBalance = initialBalance - withdraw;

        sut.Withdraw(withdraw);
        decimal actual = sut.Balance;

        Assert.Equal(expectedBalance, actual);
    }

    [Fact]
    public void Withdrawing_when_not_enough_balance_leaves_balance_unchanged() {
        decimal initialBalance = 10000;
        decimal overdraftLimit = 5000;
        decimal withdraw = 15001;
        CheckingAccount sut = new(initialBalance, overdraftLimit);

        sut.Withdraw(withdraw);
        decimal actual = sut.Balance;

        Assert.Equal(initialBalance, actual);
    }
}