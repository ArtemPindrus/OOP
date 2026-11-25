namespace Project;

public class Notifier {
    private readonly ITransport transport;

    public Notifier(ITransport transport) {
        this.transport = transport;
    }

    public void Notify(string to, string text) {
        if (string.IsNullOrWhiteSpace(to))
            throw new ArgumentException("Recipient must not be empty.", nameof(to));

        transport.Send(new Message(to, "Notification", text));
    }
}