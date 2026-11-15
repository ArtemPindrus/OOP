namespace Project;

public class PlainTextDocument : Document {
    public override void Visit(Heading heading) {
        string text = heading.Text.ToUpper();

        AppendLine(text);
    }

    public override void Visit(Paragraph paragraph) {
        AppendLine(paragraph.Text);
    }

    public override void Visit(List list) {
        foreach (var l in list.Lines) {
            AppendLine($"- {l}");
        }
    }

    protected override void StartDocument() {
        
    }

    protected override void EndDocument() {
        
    }
}
