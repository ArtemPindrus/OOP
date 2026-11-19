using System.Text;

namespace Project.Tests;

public class ListLoggerTests {
    [Fact]
    public void Logs_entries() {
        ListLogger sut = new();

        sut.Log(LogLevel.Error, "er");
        sut.Log(LogLevel.Warning, "war");
        sut.Log(LogLevel.Info, "in");

        IReadOnlyList<LogEntry> entries = sut.Entries;

        Assert.True(entries.Single(x => x.Level == LogLevel.Error && x.Message == "er") is not null);
        Assert.True(entries.Single(x => x.Level == LogLevel.Warning && x.Message == "war") is not null);
        Assert.True(entries.Single(x => x.Level == LogLevel.Info && x.Message == "in") is not null);
    }
}