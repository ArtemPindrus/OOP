namespace Project.Tests;

public class PaymentMethodTests {
    [Fact]
    public void Cheapest_returns_correct_payment_method() {
        decimal amount = 10000;
        PayPal paypal = new(); // 305
        Crypto crypto = new(); // 50
        Card card = new(); // 150
        PaymentMethod[] methods = [paypal, crypto, card];

        PaymentMethod actual = methods.Cheapest(amount);

        Assert.Equal(crypto, actual);
    }
}