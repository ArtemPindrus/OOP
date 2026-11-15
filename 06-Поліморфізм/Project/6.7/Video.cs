using Project.Exceptions;

namespace Project;

public class Video : Media {
    public string Resolution { get; }

    public Video(string title, string resolution, int duration) : base(title, duration) {
        Resolution = resolution;
    }

    public override string Play() =>
        $"Playing video: {Title} [{Resolution}] ({Format()})";
}
