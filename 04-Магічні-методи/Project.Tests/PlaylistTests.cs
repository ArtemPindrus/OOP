namespace Project.Tests;

public class PlaylistTests {
    [Fact]
    public void Addition_concatenates_two_playlists_correctly() {
        string[] songs1 = ["Song 1", "Song 2"];
        string[] songs2 = ["Song 3", "Song 4"];

        Playlist playlist1 = new(songs1);
        Playlist playlist2 = new(songs2);

        Playlist combinedPlaylist = playlist1 + playlist2;
        IEnumerable<string> actualSongs = combinedPlaylist.Songs;

        Assert.Equal(4, combinedPlaylist.Length);
        Assert.Contains(songs1[0], actualSongs);
        Assert.Contains(songs1[1], actualSongs);
        Assert.Contains(songs2[0], actualSongs);
        Assert.Contains(songs2[1], actualSongs);
    }

    [Fact]
    public void Addition_adds_song_to_playlist_correctly() {
        string[] songs = ["Song 1", "Song 2"];
        string newSong = "Song 3";
        Playlist playlist = new(songs);
        Playlist updatedPlaylist = playlist + newSong;

        IEnumerable<string> actualSongs = updatedPlaylist.Songs;

        Assert.Equal(3, updatedPlaylist.Length);
        Assert.Contains(songs[0], actualSongs);
        Assert.Contains(songs[1], actualSongs);
        Assert.Contains(newSong, actualSongs);
    }

    [Fact]
    public void Contains_returns_true_if_song_exists_in_playlist() {
        string[] songs = ["Song 1", "Song 2"];

        Playlist playlist = new(songs);

        Assert.True(playlist.Contains("Song 1"));
        Assert.True(playlist.Contains("Song 2"));
    }
}