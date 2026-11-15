namespace Project;

public class PushNotifier : Notifier {
    public override string Send(string to, string text) {
        string message = $"[Push to {to}] {text}";

        Console.WriteLine(message);
        return message;
    }
}
