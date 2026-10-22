namespace Project;

public class DepositHistoryItem : BalanceChangeHistoryItem {
    public DepositHistoryItem(double amount) : base(amount) {
    }

    public override string GetMessage() => $"Deposited: {Amount}.";
}
