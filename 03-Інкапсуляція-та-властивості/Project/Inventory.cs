namespace Project;

public class Inventory {
    private readonly Dictionary<string, int> itemToQuantity = [];

    /// <summary>
    /// Get the mapping between items and their quantity.
    /// </summary>
    public Dictionary<string, int> Items => new(itemToQuantity);

    /// <summary>
    /// Add items to the stock.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    /// <param name="quantity">Amount to add.</param>
    /// <exception cref="ArgumentException"><paramref name="quantity"/> is negative.</exception>
    public Inventory Add(string name, int quantity) {
        if (quantity < 0) throw new ArgumentException("Quantity should be positive.", nameof(quantity));

        if (itemToQuantity.ContainsKey(name)) itemToQuantity[name] += quantity;
        else itemToQuantity[name] = quantity;

        return this;
    }

    /// <summary>
    /// Remove items from the stock.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    /// <param name="quantity">Amount to remove.</param>
    /// <exception cref="ArgumentException"><paramref name="quantity"/> is negative.</exception>
    /// <exception cref="InvalidOperationException">Trying to remove more items than there are in the stock.</exception>
    public Inventory Remove(string name, int quantity) {
        if (quantity < 0) throw new ArgumentException("Quantity should be positive.", nameof(quantity));

        if (itemToQuantity.TryGetValue(name, out int v)) {
            if (quantity > v) throw new InvalidOperationException("Can't remove more items than there are in the stock.");

            itemToQuantity[name] -= quantity;
        } else throw new ArgumentException($"Item '{name}' isn't in the stock.", nameof(name));

        return this;
    }

    /// <summary>
    /// Get quantity of an item in the stock.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    public int Quantity(string name) => itemToQuantity.TryGetValue(name, out int v) ? v : 0;
}