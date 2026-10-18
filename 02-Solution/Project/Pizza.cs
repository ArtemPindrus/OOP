namespace Project;

public class Pizza {
    private const int BasePricePerSize = 100;

    private readonly List<Topping> Toppings;

    public int Size { get; }

    public Pizza(int size = 30, IEnumerable<Topping>? toppings = null) {
        if (size <= 0) throw new ArgumentOutOfRangeException("size should be greater than 0", nameof(size));

        Size = size;
        Toppings = toppings is null ? [] : new(toppings);
    }

    public Pizza Add(Topping topping) {
        Toppings.Add(topping);

        return this;
    }

    public int Price() {
        return BasePricePerSize * Size + Toppings.Count * 10;
    }
}