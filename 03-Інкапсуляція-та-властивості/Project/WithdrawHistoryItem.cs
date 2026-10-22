namespace Project;

public class WithdrawHistoryItem : BalanceChangeHistoryItem {
    public WithdrawHistoryItem(double amount) : base(amount) {
    }

    public override string GetMessage() => $"Withdrawn: {Amount}.";
}