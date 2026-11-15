using Project.Exceptions;

namespace Project;

public class Podcast : Media {
    public string Host { get; }
    public int Episode { get; }

    public Podcast(string title, string host, int episode, int duration) : base(title, duration) {
        ArgumentNegativeException.ThrowIfNegative(episode);

        Host = host;
        Episode = episode;
    }

    public override string Play() =>
        $"Playing podcast: {Title}, episode {Episode}, host {Host} ({Format()})";
}
