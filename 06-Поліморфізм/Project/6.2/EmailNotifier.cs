namespace Project;

public class EmailNotifier : Notifier {
    public override string Send(string to, string text) {
        string message = $"[Email to {to}] {text}";

        Console.WriteLine(message);
        return message;
    }
}
