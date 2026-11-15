namespace Project.Tests;

public class UpperFormaterTests {
    [Theory]
    [InlineData("hello there", "HELLO THERE")]
    [InlineData("some text with ,, pun,ctuation,", "SOME TEXT WITH ,, PUN,CTUATION,")]

    public void Returns_string_in_uppercase(string input, string expected) {
        UpperFormater sut = new();

        string actual = sut.Format(input);

        Assert.Equal(expected, actual);
    }
}

public class PipelineTests {
    [Fact]
    public void Pipiline_of_multiple_formatters_returns_correct_string() {
        string input = "\n Modiquia ut, iure, libero ipsum, sint. Eaipsum, quae facilis quia, tempore odit. Verosint, nihil, libero at, sit, vero? Dolorrem sunt facilis, sed, ea, quasi. ";
        string expected = ".isauq ,ae ,des ,silicaf tnus merroloD ?orev ,*** ,ta ****** ,lihin ,tnisoreV .tido eropmet ,aiuq silicaf eauq ,muspiaE .tnis ,muspi ****** ,erui ,tu aiuqidoM";
        Pipeline sut = new();
        string[] censoredWords = ["libero", "sit"];
        Formater[] formaters = [new TrimFormatter(), new CensorFormatter(censoredWords), new ReverseFormater()];

        string actual = sut.Format(input, formaters);

        Assert.Equal(expected, actual);
    }
}