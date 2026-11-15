using Project.Exceptions;

namespace Project.Tests;

public class PodcastTests {
    [Fact]
    public void Cant_create_podcast_with_negative_episode() {
        Assert.Throws<ArgumentNegativeException>(() => new Podcast("", "", episode: -1, duration: 10));
    }
}
