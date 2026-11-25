using Project.Exceptions;

namespace Project;

public sealed record Product {
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price) {
        ArgumentNegativeException.ThrowIfNegative(price);

        Name = name;
        Price = price;
    }

    public bool Equals(Product? other) => other is not null
        && other.Name == Name
        && other.Price == Price;

    public override int GetHashCode() => HashCode.Combine(Name, Price);

    public override string ToString() => $"{Name} ({Price:C})";
}
