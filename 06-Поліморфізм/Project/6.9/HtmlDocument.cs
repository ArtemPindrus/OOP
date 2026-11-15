namespace Project;

public class HtmlDocument : Document {
    private int indentation;

    public override void Visit(Heading heading) {
        string s = $"<h{heading.Level}>{heading.Text}</h{heading.Level}>";

        AppendLineIndented(s);
    }

    public override void Visit(Paragraph paragraph) {
        string s = $"<p>{paragraph.Text}</p>";

        AppendLineIndented(s);
    }

    public override void Visit(List list) {
        AppendLineIndented("<l>");

        indentation++;
        foreach (var l in list.Lines) {
            AppendLineIndented($"<li>{l}</li>");
        }

        indentation--;

        AppendLineIndented("</l>");
    }

    protected override void StartDocument() {
        AppendLineIndented("<html>");
        indentation++;

        AppendLineIndented("<body>");
        indentation++;
    }

    protected override void EndDocument() {
        indentation--;
        AppendLineIndented("</body>");

        indentation--;
        AppendLineIndented("</html>");
    }

    private void AppendLineIndented(string line) {
        AppendIndentation();
        AppendLine($"{line}");
    }

    private void AppendIndentation() {
        for (int i = 0; i < indentation; i++) {
            Append(new string("    "));
        }
    }
}
