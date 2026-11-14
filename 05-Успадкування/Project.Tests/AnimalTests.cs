namespace Project.Tests; 

public class AnimalTests {
    [Fact]
    public void Dog_says_bark() {
        Dog sut = new("Buddy");

        string result = sut.Intro().ToLower();

        Assert.Contains("bark", result);
    }

    [Fact]
    public void Cat_says_meow() {
        Cat sut = new("Whiskers");

        string result = sut.Intro().ToLower();

        Assert.Contains("meow", result);
    }

    [Fact]
    public void Cow_says_moo() {
        Cow sut = new("Betsy");

        string result = sut.Intro().ToLower();

        Assert.Contains("moo", result);
    }
}