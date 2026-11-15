namespace Project;

public static class PaymentMethodExtensions {
    extension(IEnumerable<PaymentMethod> methods) {
        public PaymentMethod Cheapest(decimal amount) => methods.MinBy(x => x.Pay(amount).Fee);
    }
}