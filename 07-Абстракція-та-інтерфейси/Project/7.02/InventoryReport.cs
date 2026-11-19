namespace Project;

public class InventoryReport : Report {
    private readonly Dictionary<string, int> stock;

    public InventoryReport(Dictionary<string, int> stock) => this.stock = stock;

    protected override string Header() => "=== Inventory Report ===";

    protected override IEnumerable<string> Lines() =>
        stock.Select(kv => $"{kv.Key}: {kv.Value} pcs");
}