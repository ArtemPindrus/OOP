namespace Project.Tests;

public class InventoryTests {
    [Fact]
    public void Backsup_correctly() {
        IInventory src = new MemoryInventory();
        src.Save("bananas", 10);
        src.Save("items", 4);
        IInventory dst = new MemoryInventory();
        dst.Save("other", 15);

        IInventoryUtils.Backup(src, dst);

        Assert.Equal(10, src.Load("bananas"));
        Assert.Equal(4, src.Load("items"));
    }
}