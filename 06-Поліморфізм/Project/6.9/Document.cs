using System.Text;

namespace Project;

public abstract class Document {
    private readonly StringBuilder sb = new();

    public string Render(IEnumerable<Component> components) {
        sb.Clear();
        StartDocument();

        foreach (var item in components) {
            item.Accept(this);
        }

        EndDocument();

        return sb.ToString();
    }

    public abstract void Visit(Heading heading);
    public abstract void Visit(Paragraph paragraph);
    public abstract void Visit(List list);
    protected abstract void StartDocument();
    protected abstract void EndDocument();

    protected void Append(string str) => sb.Append(str);
    protected void AppendLine(string str) => sb.Append($"{str}\r\n");
}