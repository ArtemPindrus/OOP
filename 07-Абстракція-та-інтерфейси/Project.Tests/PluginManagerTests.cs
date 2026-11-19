namespace Project.Tests;

public class PluginManagerTests {
    [Fact]
    public void Runs_registered_plugins() {
        string input = """
             some text with
            whitespace    
            """;
        string expected = """
            SOME TEXT WITH
            WHITESPACE
            """;
        PluginManager sut = new();
        sut.Register<UpperPlugin>();
        sut.Register<TrimPlugin>();

        string actual = sut.RunAll(input);

        Assert.Equal(expected, actual);
    }
}