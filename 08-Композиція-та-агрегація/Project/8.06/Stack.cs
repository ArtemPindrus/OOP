namespace Project;

public class Stack<T> {
    private readonly List<T> items = [];

    public int Size => items.Count;

    public void Push(T item) => items.Add(item);

    public T? Pop() {
        if (items.Count == 0) return default;

        int index = items.Count - 1;
        T item = items[index];
        items.RemoveAt(index);

        return item;
    }

    public T? Peek() {
        if (items.Count == 0) return default;

        int index = items.Count - 1;
        T item = items[index];

        return item;
    }
}