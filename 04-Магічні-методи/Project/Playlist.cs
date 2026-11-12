using System.Collections;

namespace Project;

public class Playlist : IEnumerable<string> {
    private readonly List<string> songs;

    public IEnumerable<string> Songs => songs;

    public int Length => songs.Count;

    public string this[int index] {
        get => songs[index];
        set => songs[index] = value;
    }

    public Playlist() {
        songs = [];
    }

    public Playlist(IEnumerable<string> songs) {
        this.songs = new(songs);
    }

    public static Playlist operator +(Playlist a, Playlist b) {
        Playlist newPlaylist = new(a.Songs.Concat(b.Songs));

        return newPlaylist;
    }

    public static Playlist operator+(Playlist playlist, string song) {
        Playlist newPlaylist = new(playlist.Songs);
        newPlaylist.AddSong(song);

        return newPlaylist;
    }

    public Playlist AddSong(string song) {
        songs.Add(song);

        return this;
    }

    public bool Contains(string song) => songs.Contains(song);

    public IEnumerator<string> GetEnumerator() => songs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}