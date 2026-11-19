namespace Project.Tests;

public class ExclaimPluginTests {
    [Fact]
    public void Returns_string_with_exclamation_point_at_the_end() {
        string input    = "Culpasunt, ipsam, eos laborum totam eos?";
        string expected = input + "!";

        ExclaimPlugin sut = new();
        string actual = sut.Run(input);

        Assert.Equal(expected, actual);
    }
}