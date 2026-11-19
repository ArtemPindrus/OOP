namespace Project.Tests;

public class StreamWriterTests {
    [Fact]
    public void Writes_logs_to_a_file_stream_correctly() {
        const string path = "file.txt";
        string expected = """
            [ERROR] some error happened
            [INFO] then this happened

            """;
        File.Delete(path);

        using (FileStream fileStream = File.Open(path, FileMode.CreateNew)) {
            StreamLogger sut = new(fileStream);
            sut.Log(LogLevel.Error, "some error happened");
            sut.Log(LogLevel.Info, "then this happened");

            fileStream.Seek(0, SeekOrigin.Begin);
        }

        string actual = File.ReadAllText(path);

        Assert.Equal(expected, actual);
    }
}