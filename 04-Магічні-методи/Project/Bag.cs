using System.Collections;

namespace Project;

public sealed class Bag<T> : IEnumerable<T>, IEquatable<Bag<T>> where T : notnull {
    private readonly Dictionary<T, int> counts = [];
    private int total;

    public Bag() { }

    public int this[T item] {
        get => counts.TryGetValue(item, out int n) ? n : 0;
        set {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Count cannot be negative.");

            int old = this[item];
            if (value == 0) counts.Remove(item);
            else counts[item] = value;
            total += value - old;
        }
    }

    public int Count => total;

    public bool Contains(T item) => this[item] > 0;

    public static Bag<T> operator +(Bag<T> a, Bag<T> b) {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        var result = new Bag<T>();
        foreach (var (k, v) in a.counts) result[k] += v;
        foreach (var (k, v) in b.counts) result[k] += v;

        return result;
    }

    public bool Equals(Bag<T>? other) {
        if (ReferenceEquals(this, other)) return true;
        if (other is null || total != other.total || counts.Count != other.counts.Count)
            return false;

        foreach (var (k, v) in counts)
            if (other[k] != v) return false;

        return true;
    }

    public override bool Equals(object? obj) => Equals(obj as Bag<T>);

    public override int GetHashCode() {
        int hash = 0;
        foreach (var (k, v) in counts) hash ^= HashCode.Combine(k, v);
        return hash;
    }

    public static bool operator ==(Bag<T>? a, Bag<T>? b) => a is null ? b is null : a.Equals(b);
    public static bool operator !=(Bag<T>? a, Bag<T>? b) => !(a == b);

    public IEnumerator<T> GetEnumerator() {
        foreach (var (k, v) in counts)
            for (int i = 0; i < v; i++)
                yield return k;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => "Bag{" + string.Join(", ", this) + "}";
}
