namespace Project.Tests;

public class HtmlDocumentTests : DocumentTests {
    [Fact]
    public void Renders_components_correctly() {
        HtmlDocument sut = new();

        string expected = """
            <html>
                <body>
                    <h1>Heading 1</h1>
                    <p>Hey, there is some text.</p>
                    <h2>Heading 2</h2>
                    <p>This is subtext.</p>
                    <l>
                        <li>item 1</li>
                        <li>item 2</li>
                        <li>item 3</li>
                    </l>
                </body>
            </html>

            """;

        string actual = sut.Render(Components);

        Assert.Equal(actual, expected);
    }
}