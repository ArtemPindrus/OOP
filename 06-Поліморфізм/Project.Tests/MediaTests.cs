using Project.Exceptions;

namespace Project.Tests;

public class MediaTests {
    [Fact]
    public void Cant_create_media_with_negative_duration() {
        Assert.Throws<ArgumentNegativeException>(() => new Video("", "", duration: -1));
        Assert.Throws<ArgumentNegativeException>(() => new Podcast("", "", 10, duration: -1));
        Assert.Throws<ArgumentNegativeException>(() => new Song("", "", duration: -1));
    }
}