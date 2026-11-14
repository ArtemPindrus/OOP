namespace Project;

public class Stack<T> {
    protected readonly List<T> list;

    public Stack() {
        list = new();
    }

    public Stack(IEnumerable<T> items) {
        list = new(items);
    }

    public virtual void Push(T item) {
        list.Add(item);
    }

    public T? Pop() {
        int length = list.Count;

        if (length > 0) {
            int ind = length - 1;

            T item = list[ind];
            list.RemoveAt(ind);

            return item;
        }

        throw new InvalidOperationException("Can't pop items off an empty stack.");
    }
}