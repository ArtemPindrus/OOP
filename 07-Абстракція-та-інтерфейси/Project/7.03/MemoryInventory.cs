namespace Project;

public class MemoryInventory : IInventory {
    private readonly Dictionary<string, object?> dict = [];

    public bool Delete(string key) => dict.Remove(key);

    public IEnumerable<string> Keys() => dict.Keys;

    public object? Load(string key) => dict[key];

    public void Save(string key, object? value) => dict[key] = value;
}