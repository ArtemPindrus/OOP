namespace Project;

public class Crypto : PaymentMethod {
    public override PaymentResult Pay(decimal amount) {
        decimal fee = amount * 0.005m;

        return new PaymentResult(amount + fee, fee);
    }
}