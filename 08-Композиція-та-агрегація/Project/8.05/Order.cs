using Project.Exceptions;

namespace Project;

public class Order {
    private readonly List<OrderLine> lines = [];

    public void Add(Product product, int quantity) {
        ArgumentNullException.ThrowIfNull(product);
        ArgumentNegativeException.ThrowIfNegative(quantity);

        int index = lines.FindIndex(l => l.Product == product);
        if (index >= 0)
            lines[index] = new OrderLine(product, lines[index].Quantity + quantity);
        else
            lines.Add(new OrderLine(product, quantity));
    }

    public decimal Total() => lines.Sum(l => l.Subtotal);

    public IReadOnlyList<OrderLine> Lines() => lines;
}