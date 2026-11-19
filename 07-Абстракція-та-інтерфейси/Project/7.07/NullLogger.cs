namespace Project;

public class NullLogger : ILogger {
    public void Log(LogLevel level, string msg) { }
}
