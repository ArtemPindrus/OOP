namespace Project;

public class Heading : Component {
    public int Level { get; }
    public string Text { get; }

    public Heading(string text, int level) {
        Text = text;
        Level = level;
    }

    public override void Accept(Document doc) => doc.Visit(this);
}
