namespace Project.Tests;

public class AccountTests {
    [Fact]
    public void Cant_withdraw_negative_amount() {
        Account sut = new(10000);

        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Withdraw(-100));
    }

    [Fact]
    public void Cant_deposit_negative_amount() {
        Account sut = new(10000);

        Assert.Throws<ArgumentOutOfRangeException>(() => sut.Deposit(-100));
    }

    [Fact]
    public void Withdrawing_when_enough_balance_reduces_balance() {
        decimal initialBalance = 10000;
        decimal withdraw = 9000;
        Account sut = new(initialBalance);
        decimal expectedBalance = initialBalance - withdraw;

        sut.Withdraw(withdraw);
        decimal actual = sut.Balance;

        Assert.Equal(expectedBalance, actual);
    }

    [Fact]
    public void Withdrawing_when_not_enough_balance_leaves_balance_unchanged() {
        decimal initialBalance = 10000;
        decimal withdraw = 11000;
        Account sut = new(initialBalance);

        sut.Withdraw(withdraw);
        decimal actual = sut.Balance;

        Assert.Equal(initialBalance, actual);
    }
}