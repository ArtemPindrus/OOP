namespace Project;

public class List : Component {
    public string[] Lines { get; }

    public List(string[] lines) {
        Lines = lines;
    }

    public override void Accept(Document doc) => doc.Visit(this);
}
