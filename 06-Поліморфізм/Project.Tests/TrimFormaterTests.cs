namespace Project.Tests;

public class TrimFormaterTests {
    [Theory]
    [InlineData("   hello there ", "hello there")]
    [InlineData("\n\n  asd \n \n", "asd")]

    public void Returns_trimmed_string(string input, string expected) {
        TrimFormatter sut = new();

        string actual = sut.Format(input);

        Assert.Equal(expected, actual);
    }
}