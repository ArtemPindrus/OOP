namespace Project;

public class ListLogger : ILogger {
    private readonly List<LogEntry> entries = [];

    public IReadOnlyList<LogEntry> Entries => entries;

    public void Log(LogLevel level, string msg) => entries.Add(new LogEntry(level, msg));
}
