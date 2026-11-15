namespace Project;

public abstract class PaymentMethod {
    public string Name { get; }

    protected PaymentMethod() {
        Name = GetType().Name;
    }

    public abstract PaymentResult Pay(decimal amount);
}