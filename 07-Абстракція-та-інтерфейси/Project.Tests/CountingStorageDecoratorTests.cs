namespace Project.Tests;

public class CountingStorageDecoratorTests {
    [Fact]
    public void Counts_operations_correctly() {
        CountingStorageDecorator sut = new(new MemoryInventory());
        sut.Save("bananas", 10);
        sut.Save("items", 4);
        sut.Delete("bananas");
        sut.Load("items");

        Assert.Equal(2, sut.Saves);
        Assert.Equal(1, sut.Deletes);
        Assert.Equal(1, sut.Loads);
    }
}