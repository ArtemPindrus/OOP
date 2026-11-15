namespace Project;

public class Paragraph : Component {
    public string Text { get; }

    public Paragraph(string text) {
        Text = text;
    }

    public override void Accept(Document doc) => doc.Visit(this);
}
