namespace Project;

public class FakeTransport : ITransport {
    private readonly List<Message> sent = [];

    public IReadOnlyList<Message> Sent => sent;

    public void Send(Message message) {
        sent.Add(message);
    }
}
