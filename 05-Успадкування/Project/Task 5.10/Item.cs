namespace Project;

public class Item {
    public string Name { get; }
    public int Weight { get; }

    public Item(string name, int weight) {
        if (weight < 0) throw new ArgumentException("Argument can't be negative.", nameof(weight));

        Name = name;
        Weight = weight;
    }
}
