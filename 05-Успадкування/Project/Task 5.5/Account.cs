namespace Project;

public class Account {
    public decimal Balance { get; protected set; }

    public Account(decimal balance = 0m) {
        Balance = balance;
    }

    public void Deposit(decimal amount) {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Balance += amount;
    }

    public virtual bool Withdraw(decimal amount) {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (amount > Balance) return false;

        Balance -= amount;
        return true;
    }
}