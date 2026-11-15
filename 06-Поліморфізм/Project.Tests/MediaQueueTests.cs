namespace Project.Tests;

public class MediaQueueTests {
    [Fact]
    public void TotalDuration_returns_correct_value() {
        MediaQueue sut = new();
        sut.Add(new Video("", "", duration: 100))
           .Add(new Song("", "", duration: 15))
           .Add(new Podcast("", "", 0, duration: 35))
           .Add(new Video("", "", duration: 11));
        int expected = 100 + 15 + 35 + 11;

        int actual = sut.TotalDuration();

        Assert.Equal(expected, actual);
    }
}