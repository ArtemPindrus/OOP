namespace Project;

public class Version : IComparable<Version> {
    public int Major { get; }
    public int Minor { get; }
    public int Patch { get; }

    public Version(int major, int minor, int patch) {
        if (major < 0 || minor < 0 || patch < 0) {
            throw new ArgumentException("Version components must be non-negative.");
        }

        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public override string ToString() => $"{Major}.{Minor}.{Patch}";

    public override int GetHashCode() => HashCode.Combine(Major, Minor, Patch);

    public override bool Equals(object? obj) => obj is Version version && this == version;

    public int CompareTo(Version? other) {
        if (other is null) return 1;

        if (this > other) return 1;
        if (this < other) return -1;
        else return 0;
    }

    public static bool operator >(Version v1, Version v2) {
        if (v1.Major > v2.Major) return true;
        if (v1.Major < v2.Major) return false;
        if (v1.Minor > v2.Minor) return true;
        if (v1.Minor < v2.Minor) return false;

        return v1.Patch > v2.Patch;
    }

    public static bool operator <(Version v1, Version v2) {
        if (v1.Major < v2.Major) return true;
        if (v1.Major > v2.Major) return false;
        if (v1.Minor < v2.Minor) return true;
        if (v1.Minor > v2.Minor) return false;

        return v1.Patch < v2.Patch;
    }

    public static bool operator ==(Version v1, Version v2) => v1.Major == v2.Major 
        && v1.Minor == v2.Minor
        && v1.Patch == v2.Patch;

    public static bool operator !=(Version v1, Version v2) => !(v1 == v2);
}