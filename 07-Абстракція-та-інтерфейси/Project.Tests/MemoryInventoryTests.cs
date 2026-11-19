namespace Project.Tests;

public class MemoryInventoryTests {
    [Fact]
    public void Load_on_empty_inventory_throws() {
        Assert.Throws<KeyNotFoundException>(() => new MemoryInventory().Load(""));
    }
}
