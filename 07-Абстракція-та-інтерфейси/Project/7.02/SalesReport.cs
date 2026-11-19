namespace Project;

public class SalesReport : Report {
    private readonly Dictionary<string, decimal> sales;

    public SalesReport(Dictionary<string, decimal> sales) => this.sales = sales;

    protected override string Header() => "=== Sales Report ===";

    protected override IEnumerable<string> Lines() =>
        sales.Select(kv => $"{kv.Key}: {kv.Value:F2}");

    protected override string Footer() => $"Total: {sales.Values.Sum():F2}";
}
