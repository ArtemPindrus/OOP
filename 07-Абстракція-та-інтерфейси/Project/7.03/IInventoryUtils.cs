namespace Project;

public static class IInventoryUtils {
    public static void Backup(IInventory src, IInventory dst) {
        IEnumerable<string> keys = src.Keys();

        foreach (var k in keys) {
            object? value = src.Load(k);
            dst.Save(k, value);
        }
    }
}