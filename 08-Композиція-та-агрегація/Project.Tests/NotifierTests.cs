namespace Project.Tests;

public class NotifierTests {
    [Fact]
    public void Notify_DeliversMessageToTransport() {
        var fake = new FakeTransport();
        var notifier = new Notifier(fake);

        notifier.Notify("anna@example.com", "Your order has shipped");

        Assert.Single(fake.Sent);
        Assert.Equal("anna@example.com", fake.Sent[0].To);
        Assert.Equal("Your order has shipped", fake.Sent[0].Body);
    }

    [Fact]
    public void Notify_WithEmptyRecipient_SendsNothing() {
        var fake = new FakeTransport();
        var notifier = new Notifier(fake);

        Assert.Throws<ArgumentException>(() => notifier.Notify("", "text"));
        Assert.Empty(fake.Sent);
    }
}