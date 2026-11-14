namespace Project;

public class CountingStack<T> : Stack<T> {
    public int PushCount { get; private set; }

    public CountingStack() : base() {

    }

    public CountingStack(IEnumerable<T> items) : base(items) {
        PushCount = list.Count;
    }

    public override void Push(T item) {
        base.Push(item);

        PushCount++;
    }
}