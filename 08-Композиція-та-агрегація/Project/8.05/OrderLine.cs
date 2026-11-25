using Project.Exceptions;

namespace Project;

public sealed record class OrderLine {
    public Product Product { get; }
    public int Quantity { get; }
    public decimal Subtotal => Product.Price * Quantity;

    public OrderLine(Product product, int quantity) {
        ArgumentNegativeException.ThrowIfNegative(quantity);

        Product = product;
        Quantity = quantity;
    }

    public bool Equals(OrderLine? other) => other is not null
        && other.Product == Product
        && other.Quantity == Quantity;

    public override int GetHashCode() => HashCode.Combine(Product, Quantity);

    public override string ToString() => $"{Product.Name} x{Quantity} = {Subtotal:C}";
}
