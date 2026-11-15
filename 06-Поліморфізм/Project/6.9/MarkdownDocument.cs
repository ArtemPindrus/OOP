namespace Project;

public class MarkdownDocument : Document {
    public override void Visit(Heading heading) {
        string s = new string('#', heading.Level) + " " + heading.Text;

        AppendLine(s);
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
