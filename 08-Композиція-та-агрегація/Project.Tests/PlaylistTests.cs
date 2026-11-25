namespace Project.Tests;

public class PlaylistTests {
    [Fact]
    public void ShallowCopy_returns_with_the_same_instances_of_songs() {
        Song s1 = new("Bob", "S1");
        Song s2 = new("Bob2", "S2");
        Song s3 = new("Bob3", "S3");

        Playlist sut = new([s1, s2, s3]);
        Playlist copy = sut.ShallowCopy();

        IEnumerable<Song> songs = copy.Songs;

        Assert.Equal(3, songs.Count());
        Assert.Contains(songs, x => ReferenceEquals(x, s1));
        Assert.Contains(songs, x => ReferenceEquals(x, s2));
        Assert.Contains(songs, x => ReferenceEquals(x, s3));
    }

    [Fact]
    public void DeepCopy_returns_with_different_instances_of_songs() {
        Song s1 = new("Bob", "S1");
        Song s2 = new("Bob2", "S2");
        Song s3 = new("Bob3", "S3");

        Playlist sut = new([s1, s2, s3]);
        Playlist copy = sut.DeepCopy();

        IEnumerable<Song> songs = copy.Songs;

        Assert.Equal(3, songs.Count());
        Assert.DoesNotContain(songs, x => ReferenceEquals(x, s1));
        Assert.DoesNotContain(songs, x => ReferenceEquals(x, s2));
        Assert.DoesNotContain(songs, x => ReferenceEquals(x, s3));
    }
}