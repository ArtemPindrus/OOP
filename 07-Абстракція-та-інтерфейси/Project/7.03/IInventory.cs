namespace Project;

public interface IInventory {
    void Save(string key, object? value);
    object? Load(string key);

    /// <summary>
    /// Delete key from inventory.
    /// </summary>
    /// <returns>true if key existed and was deleted. false if not key existed.</returns>
    bool Delete(string key);

    IEnumerable<string> Keys();
}