namespace Project;

public class SavingsAccount : Account {
    public decimal InterestRate { get; }

    public SavingsAccount(decimal balance, decimal interestRate) : base(balance) {
        InterestRate = interestRate;
    }

    public void AddInterest() => Balance += Balance * InterestRate;
}
