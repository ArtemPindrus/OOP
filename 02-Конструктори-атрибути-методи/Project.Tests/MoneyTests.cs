namespace Project.Tests;

public class MoneyTests {
    [TestCase("10", 100)]
    [TestCase("12", 120)]
    [TestCase("12.5", 125)]
    [TestCase("12.55", 125)]
    [TestCase("12.65", 126)]
    public void FromString_AmountInCoinsIsCorrect(string str, int coins) {
        Money money = Money.FromString(str);

        int actual = money.AmountInCoins;

        Assert.That(actual, Is.EqualTo(coins));
    }

    [TestCase(0, "0.00 UAH")]
    [TestCase(1, "0.01 UAH")]
    [TestCase(12, "0.12 UAH")]
    [TestCase(120, "1.20 UAH")]
    [TestCase(125, "1.25 UAH")]
    [TestCase(1300, "13.00 UAH")]
    public void ToString_ReturnsCorrectValue(int coins, string expected) {
        Money m = new(coins);

        string actual = m.ToString();

        Assert.That(actual, Is.EqualTo(expected));
    }
}