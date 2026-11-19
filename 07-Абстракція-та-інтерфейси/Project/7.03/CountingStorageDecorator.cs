namespace Project;

public class CountingStorageDecorator : IInventory {
    private readonly IInventory decoratee;

    public int Deletes { get; private set; }
    public int Loads { get; private set; }
    public int Saves { get; private set; }

    public CountingStorageDecorator(IInventory inventory) {
        this.decoratee = inventory;
    }

    public bool Delete(string key) {
        bool v = decoratee.Delete(key);
        Deletes++;

        return v;
    }

    public object? Load(string key) {
        object? v = decoratee.Load(key);
        Loads++;

        return v;
    }

    public void Save(string key, object? value) {
        decoratee.Save(key, value);
        Saves++;
    }

    public IEnumerable<string> Keys() => decoratee.Keys();
}