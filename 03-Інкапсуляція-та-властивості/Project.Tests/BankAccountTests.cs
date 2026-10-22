namespace Project.Tests;

public class BankAccountTests {
    [Test]
    public void History_IsRecordedCorrectly() {
        BankAccount b = new("Bob");

        b.Deposit(1000);
        b.Withdraw(500);
        b.Withdraw(500);

        b.Deposit(200);
        b.Withdraw(100);
        b.Withdraw(50);
        b.Withdraw(50);

        IHistoryItem[] actual = b.History;

        IHistoryItem[] expected = [
            new DepositHistoryItem(1000),
            new WithdrawHistoryItem(500),
            new WithdrawHistoryItem(500),
            new DepositHistoryItem(200),
            new WithdrawHistoryItem(100),
            new WithdrawHistoryItem(50),
            new WithdrawHistoryItem(50),
        ];

        Assert.That(actual, Has.Length.EqualTo(expected.Length));

        for (int i = 0; i < actual.Length; i++) {
            var actualItem = actual[i];
            var expectedItem = expected[i];

            Assert.That(actualItem.GetMessage(), Is.EqualTo(expectedItem.GetMessage()));
        }
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Constructor_ThrowsWhenOwnerIsInvalid(string? owner) {
        Assert.Throws<ArgumentException>(() => new BankAccount(owner!));
    }

    [Test]
    public void Constructor_ThrowsWhenBalanceIsNegative() {
        Assert.Throws<ArgumentException>(() => new BankAccount("Bob", -1));
        Assert.Throws<ArgumentException>(() => new BankAccount("Bob", -100));
    }

    [Test]
    public void Deposit_ThrowsWhenArgumentIsNegative() {
        BankAccount b = new("Bob", 100);

        Assert.Throws<ArgumentException>(() => b.Deposit(-1));
    }

    [TestCase(100, 100, 200)]
    [TestCase(100, 50, 150)]
    public void Deposit_AddsToBalance(double initial, double deposit, double expected) {
        BankAccount b = new("Bob", initial);

        b.Deposit(deposit);

        double actual = b.Balance;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Withdraw_ThrowsWhenArgumentIsNegative() {
        BankAccount b = new("Bob", 100);

        Assert.Throws<ArgumentException>(() => b.Withdraw(-1));
    }

    [TestCase(100, 100, 0)]
    [TestCase(100, 50, 50)]
    public void Withdraw_SubtractsFromBalance(double initial, double amount, double expected) {
        BankAccount b = new("Bob", initial);

        b.Withdraw(amount);

        double actual = b.Balance;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Withdraw_ThrowsWhenNotEnoughBalance() {
        BankAccount b = new("Bob", 10);

        Assert.Throws<InvalidOperationException>(() => b.Withdraw(11));
        Assert.Throws<InvalidOperationException>(() => b.Withdraw(110));
    }
}