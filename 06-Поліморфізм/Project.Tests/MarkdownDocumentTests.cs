namespace Project.Tests;

public class MarkdownDocumentTests : DocumentTests {
    [Fact]
    public void Renders_components_correctly() {
        MarkdownDocument sut = new();

        string expected = """
            # Heading 1
            Hey, there is some text.
            ## Heading 2
            This is subtext.
            - item 1
            - item 2
            - item 3

            """;

        string actual = sut.Render(Components);

        Assert.Equal(actual, expected);
    }
}