namespace ObjectProject.Services;

public class TimePrefixLoggerDecorator : ILogger {
    private readonly ILogger decoratee;

    public TimePrefixLoggerDecorator(ILogger decoratee) {
        this.decoratee = decoratee;
    }

    public void LogInfo(string message) {
        decoratee.LogInfo($"[{TimeOnly.FromDateTime(DateTime.Now):HH:mm:ss}] {message}");
    }
}