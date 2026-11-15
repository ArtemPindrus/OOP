namespace Project.Tests;

public class DocumentTests {
    protected IEnumerable<Component> Components { get; }

    public DocumentTests() {
        Components = [
            new Heading("Heading 1", 1),
            new Paragraph("Hey, there is some text."),
            new Heading("Heading 2", 2),
            new Paragraph("This is subtext."),
            new List(["item 1", "item 2", "item 3"])
        ];
    }
}
