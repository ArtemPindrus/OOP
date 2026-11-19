using System.Text;

namespace Project;

public class MemoryFile : IReadable, IWritable {
    public StringBuilder sb = new();

    public string Read() => sb.ToString();

    public void Write(string text) => sb.Append(text);
}
