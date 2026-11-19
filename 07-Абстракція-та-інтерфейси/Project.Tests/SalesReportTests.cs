namespace Project.Tests;

public class SalesReportTests {
    [Fact]
    public void Formats_correctly() {
        string expected = """
            === Sales Report ===
            Banana: 10,00
            Toilet paper: 55,00
            Olive oil: 2,00
            Total: 67,00
            """;
        Dictionary<string, decimal> sales = new() {
            { "Banana", 10 },
            { "Toilet paper", 55 },
            { "Olive oil", 2 },
        };
        SalesReport sut = new(sales);

        string actual = sut.Build();

        Assert.Equal(expected, actual);
    }
}