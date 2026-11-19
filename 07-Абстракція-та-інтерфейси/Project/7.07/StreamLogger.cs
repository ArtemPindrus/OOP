using System.Text;

namespace Project;

public class StreamLogger : ILogger {
    private readonly StreamWriter writer;

    public StreamLogger(Stream stream) {
        writer = new StreamWriter(stream, new UTF8Encoding(false), 1024, leaveOpen: true) {
            AutoFlush = true
        };
    }

    public void Log(LogLevel level, string msg) =>
        writer.WriteLine($"[{level.ToString().ToUpper()}] {msg}");
}
