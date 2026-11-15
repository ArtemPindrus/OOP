namespace Project.Tests;

public class PlainTextDocumentTests : DocumentTests {
    [Fact]
    public void Renders_components_correctly() {
        PlainTextDocument sut = new();

        string expected = """
            HEADING 1
            Hey, there is some text.
            HEADING 2
            This is subtext.
            - item 1
            - item 2
            - item 3

            """;

        string actual = sut.Render(Components);

        Assert.Equal(actual, expected);
    }
}