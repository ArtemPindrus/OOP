namespace Project.Tests;

public class CensorFormaterTests {
    [Fact]
    public void Returns_string_with_words_censored_by_asterisk() {
        string[] censoredWords = ["world", "you"];
        string input    = "the world says hello to you! worldwide";
        string expected = "the ***** says hello to ***! *****wide";
        CensorFormatter sut = new(censoredWords);

        string actual = sut.Format(input);

        Assert.Equal(expected, actual);
    }
}