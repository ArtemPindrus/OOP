namespace Project.Tests;

public class QuoteCollectorTests {
    [Fact]
    public void Chorus_collects_all_quotes() {
        Duck d = new();
        Person p = new();
        Robot r = new();
        Person p2 = new();
        object[] arr = [d,p,r,p2];
        string[] expected = [d.Quote(), p.Quote(), r.Quote(), p2.Quote()];

        string[] actual = QuoteCollector.Chorus(arr);

        Assert.Equal(expected, actual);
    }
}