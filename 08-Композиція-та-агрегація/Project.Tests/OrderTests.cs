namespace Project.Tests;

public class OrderTests {
    [Fact]
    public void Merges_identical_products() {
        Order sut = new();
        sut.Add(new Product("Banana", 10), 10);
        sut.Add(new Product("Banana", 10), 5);

        IReadOnlyList<OrderLine> lines = sut.Lines();

        Assert.Single(lines);
        Assert.Contains(new OrderLine(new Product("Banana", 10), 15), lines);
    }

    [Fact]
    public void Total_is_correct() {
        Order sut = new();
        sut.Add(new Product("Banana", 10), 10); // 100
        sut.Add(new Product("Banana", 10), 5); // 50
        sut.Add(new Product("Banana", 20.5m), 10); // 205
        decimal expected = 355m;

        decimal actual = sut.Total();

        Assert.Equal(expected, actual);
    }
}