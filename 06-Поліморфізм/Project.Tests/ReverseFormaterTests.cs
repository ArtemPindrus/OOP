namespace Project.Tests;

public class ReverseFormaterTests {
    [Theory]
    [InlineData("hello there", "ereht olleh")]
    [InlineData("other ,, text in here.", ".ereh ni txet ,, rehto")]

    public void Returns_reversed_string(string input, string expected) {
        ReverseFormater sut = new();

        string actual = sut.Format(input);

        Assert.Equal(expected, actual);
    }
}