namespace ObjectProject.Services;

public class ConsoleLogger : ILogger {
    public void LogInfo(string message) {
        Console.WriteLine(message);
    }
}
