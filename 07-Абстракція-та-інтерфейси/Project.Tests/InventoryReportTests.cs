namespace Project.Tests;

public class InventoryReportTests {
    [Fact]
    public void Formats_correctly() {
        string expected = """
            === Inventory Report ===
            Banana: 10 pcs
            Toilet paper: 55 pcs
            Olive oil: 2 pcs
            === End of report ===
            """;
        Dictionary<string, int> inv = new() {
            { "Banana", 10 },
            { "Toilet paper", 55 },
            { "Olive oil", 2 },
        };
        InventoryReport sut = new(inv);

        string actual = sut.Build();

        Assert.Equal(expected, actual);
    }
}