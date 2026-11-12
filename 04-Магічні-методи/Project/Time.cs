using System.Text.RegularExpressions;

namespace Project;

public class Time {
    private static readonly Regex stringRegex = new(@"^(\d\d):(\d\d):(\d\d)$");

    public int Hours { get; }
    public int Minutes { get; }
    public int Seconds { get; }

    public Time(int hours, int minutes, int seconds) {
        if (minutes < 0 || minutes >= 60) throw new ArgumentException("Minutes must be between 0 and 59.", nameof(minutes));
        if (seconds < 0 || seconds >= 60) throw new ArgumentException("Seconds must be between 0 and 59.", nameof(seconds));

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int ToSeconds() {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }

    public static Time FromSeconds(int seconds) {
        if (seconds < 0) throw new ArgumentException("Seconds cannot be negative.", nameof(seconds));
        
        int hours = seconds / 3600;
        seconds %= 3600;

        int minutes = seconds / 60;
        seconds %= 60;

        return new Time(hours, minutes, seconds);
    }

    public static Time FromString(string str) {
        Match match = stringRegex.Match(str);

        if (!match.Success) throw new ArgumentException("Invalid time format. Expected HH:MM:SS.", nameof(str));
        
        int hours = int.Parse(match.Groups[1].Value);
        int minutes = int.Parse(match.Groups[2].Value);
        int seconds = int.Parse(match.Groups[3].Value);

        return new Time(hours, minutes, seconds);
    }

    public static Time operator+(Time t1, Time t2) {
        int totalSeconds = t1.ToSeconds() + t2.ToSeconds();
        return FromSeconds(totalSeconds);
    }

    public static Time operator -(Time t1, Time t2) {
        int totalSeconds = t1.ToSeconds() - t2.ToSeconds();
        return FromSeconds(totalSeconds);
    }

    public static bool operator ==(Time t1, Time t2) {
        if (ReferenceEquals(t1, t2)) return true;
        if (t1 is null || t2 is null) return false;

        return t1.Hours == t2.Hours 
            && t1.Minutes == t2.Minutes 
            && t1.Seconds == t2.Seconds;
    }

    public static bool operator !=(Time t1, Time t2) {
        return !(t1 == t2);
    }

    public override bool Equals(object? obj) => obj is Time t && this == t;

    public override int GetHashCode() => HashCode.Combine(Hours, Minutes, Seconds);
}