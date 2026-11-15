using Project.Exceptions;

namespace Project;

public abstract class Media {
    public string Title { get; }
    public int Duration { get; }

    protected Media(string title, int duration) {
        ArgumentNegativeException.ThrowIfNegative(duration);

        Title = title;
        Duration = duration;
    }

    /// <summary>
    /// Returns a string describing the playback.
    /// </summary>
    public abstract string Play();

    protected string Format() {
        return $"{Duration / 60}:{Duration % 60:D2}";
    }
}