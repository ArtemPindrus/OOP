namespace Project;

public class CheckingAccount : Account {
    public decimal OverdraftLimit { get; }

    public CheckingAccount(decimal balance, decimal overdraftLimit) : base(balance) {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount) {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (amount > Balance + OverdraftLimit) return false;

        Balance -= amount;
        return true;
    }
}
