namespace Project;

public class Product {
    public string Name { get; }
    public double Price { get; }

    public int Discount { 
        get; 
        set {
            if (value < 0 || value > 100) {
                throw new ArgumentOutOfRangeException(nameof(value), "Discount must be between 0 and 100.");
            }

            field = value;
        }
    }

    public Product(string name, double price, int discount = 0) {
        Name = name;
        Price = price;
        Discount = discount;
    }

    public double GetFinalPrice() {
        double normalizedDiscount = Discount / 100.0;
        double discountMultuplier = 1 - normalizedDiscount;

        return Price * discountMultuplier;
    }

    public double Total(int quantity) {
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be non-negative.");

        return GetFinalPrice() * quantity;
    }
}
