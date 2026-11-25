using Project.Exceptions;
using System.Net.Mail;

namespace Project;

public class SmtpTransport : ITransport {
    private readonly string host;
    private readonly int port;
    private readonly string from;

    public SmtpTransport(string host, int port, string from) {
        ArgumentNullException.ThrowIfNull(host);
        ArgumentNullException.ThrowIfNull(from);
        ArgumentNegativeException.ThrowIfNegative(port);

        this.host = host;
        this.from = from;
        this.port = port;
    }

    public void Send(Message message) {
        using var client = new SmtpClient(host, port);
        using var mail = new MailMessage(from, message.To, message.Subject, message.Body);
        client.Send(mail);
    }
}
