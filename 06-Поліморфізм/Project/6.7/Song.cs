namespace Project;

public class Song : Media {
    public string Artist { get; }

    public Song(string title, string artist, int duration) : base(title, duration) {
        Artist = artist;
    }

    public override string Play() =>
        $"Playing song: {Artist} - {Title} ({Format()})";
}
