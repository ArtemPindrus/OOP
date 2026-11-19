namespace Project;

public interface ILogger {
    void Log(LogLevel level, string msg);
}