namespace Project;

public class ReadOnlyFile : IReadable {
    private readonly string content;

    public ReadOnlyFile(string content) => this.content = content;

    public string Read() => content;
}
