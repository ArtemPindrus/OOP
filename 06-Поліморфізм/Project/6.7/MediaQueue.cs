namespace Project;

public class MediaQueue {
    private readonly List<Media> items = [];

    public MediaQueue Add(Media media) {
        ArgumentNullException.ThrowIfNull(media);

        items.Add(media);
        return this;
    }

    public int TotalDuration() => items.Aggregate(0, (acc, m) => acc + m.Duration);

    public List<string> PlayAll() => items.Select(x => x.Play()).ToList();
}