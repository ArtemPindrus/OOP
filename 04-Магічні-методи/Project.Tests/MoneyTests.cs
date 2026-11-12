namespace Project.Tests;

public class MoneyTests {
    [Fact]
    public void Cant_add_different_currencies() {
        var money1 = new Money(100, Currency.USD);
        var money2 = new Money(100, Currency.EUR);

        Assert.Throws<InvalidOperationException>(() => { var result = money1 + money2; });
    }

    [Fact]
    public void Equals_returns_true_for_same_amount_and_currency() {
        var money1 = new Money(100, Currency.USD);
        var money2 = new Money(100, Currency.USD);

        Assert.True(money1.Equals(money2));
    }

    [Fact]
    public void Adding_two_money_objects_with_same_currency_returns_correct_result() {
        var money1 = new Money(100, Currency.USD);
        var money2 = new Money(50, Currency.USD);

        var result = money1 + money2;

        Assert.Equal(150, result.Amount);
        Assert.Equal(Currency.USD, result.Currency);
    }
}