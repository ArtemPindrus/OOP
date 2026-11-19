namespace Project.Tests;

public class UpperPluginTests {
    [Fact]
    public void Returns_string_in_uppercase() {
        string input    = "Culpasunt, ipsam, eos laborum totam eos?";
        string expected = "CULPASUNT, IPSAM, EOS LABORUM TOTAM EOS?";

        UpperPlugin sut = new();
        string actual = sut.Run(input);

        Assert.Equal(expected, actual);
    }
}
