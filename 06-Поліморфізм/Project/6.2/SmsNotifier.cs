namespace Project;

public class SmsNotifier : Notifier {
    private const int MaxLength = 20;

    public override string Send(string to, string text) {
        string truncated = text.Length > MaxLength ? text.Substring(0, MaxLength) : text;
        string message = $"[SMS to {to}] {truncated}";

        Console.WriteLine(message);
        return message;
    }
}
