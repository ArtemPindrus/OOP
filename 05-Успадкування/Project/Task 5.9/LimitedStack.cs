namespace Project;

public class LimitedStack<T> : Stack<T> {
    public int Limit { get; }

    public LimitedStack(int limit) {
        Limit = limit;
    }

    public LimitedStack(int limit, IEnumerable<T> items) : base(items) {
        Limit = limit;
    }

    public override void Push(T item) {
        if (list.Count >= Limit) throw new InvalidOperationException("Stack capacity overflowed.");

        base.Push(item);
    }
}
