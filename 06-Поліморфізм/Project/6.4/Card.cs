namespace Project;

public class Card : PaymentMethod {
    public override PaymentResult Pay(decimal amount) {
        decimal fee = amount * 0.015m;

        return new PaymentResult(amount + fee, fee);
    }
}
