namespace Project;

public abstract class BalanceChangeHistoryItem : IHistoryItem {
    public BalanceChangeHistoryItem(double amount) {
        Amount = amount;
    }

    public double Amount { get; }

    public abstract string GetMessage();
}
