namespace Project;

public class Playlist {
    private readonly List<Song> songs;

    public IEnumerable<Song> Songs => songs;

    public Playlist() {
        songs = [];
    }

    public Playlist(IEnumerable<Song> songs) {
        this.songs = songs.ToList();
    }

    public Playlist ShallowCopy() => new(Songs);

    public Playlist DeepCopy() => new(Songs.Select(s => s.DeepCopy()));
}