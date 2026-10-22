namespace Project;

public class BankAccount {
    private readonly List<IHistoryItem> history = [];

    /// <summary>
    /// Get the owner of this bank account.
    /// </summary>
    public string Owner { get; }

    /// <summary>
    /// Get account's balance.
    /// </summary>
    public double Balance { get; private set; }

    /// <summary>
    /// Get the history of operations.
    /// </summary>
    public IHistoryItem[] History => history.ToArray();

    public BankAccount(string owner, double initialBalance = 0) {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner must not be empty.");
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");

        Owner = owner;
        Balance = initialBalance;
    }

    /// <summary>
    /// Add money to the balance.
    /// </summary>
    /// <param name="amount">Positive amount of money.</param>
    /// <exception cref="ArgumentException"><paramref name="amount"/> is negative.</exception>
    public void Deposit(double amount) {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");

        Balance += amount;
        history.Add(new DepositHistoryItem(amount));
    }

    /// <summary>
    /// Subtract money from the balance.
    /// </summary>
    /// <param name="amount">Positive amount of money.</param>
    /// <exception cref="ArgumentException"><paramref name="amount"/> is negative.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="amount"/> is less than <see cref="Balance"/>.</exception>
    public void Withdraw(double amount) {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds: balance cannot go below 0.");

        Balance -= amount;
        history.Add(new WithdrawHistoryItem(amount));
    }
}
