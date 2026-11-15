namespace Project;

public class PayPal : PaymentMethod {
    public override PaymentResult Pay(decimal amount) {
        decimal fee = amount * 0.03m + 5m;

        return new PaymentResult(amount + fee, fee);
    }
}
