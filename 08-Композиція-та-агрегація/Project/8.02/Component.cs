using Project.Exceptions;

namespace Project;

public abstract class HardwareComponent {
    public string Name { get; }
    public string Characteristic { get; }
    public decimal Price { get; }

    protected HardwareComponent(string name, string characteristic, decimal price) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name must not be empty.", nameof(name));
        ArgumentNegativeException.ThrowIfNegative(price);

        Name = name;
        Characteristic = characteristic;
        Price = price;
    }

    public override string ToString() =>
        $"{GetType().Name}: {Name} ({Characteristic}) - {Price:C}";
}