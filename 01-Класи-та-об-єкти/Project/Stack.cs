namespace Project;

public class Stack {
    private readonly List<int> stack;

    public int Size => stack.Count;

    public bool IsEmpty => stack.Count == 0;

    public Stack() {
        stack = new List<int>();
    }

    public Stack(IEnumerable<int> values) {
        stack = new(values);
    }

    public void Push(int value) => stack.Add(value);

    public int? Pop() {
        if (stack.Count == 0) return null;
        
        int index = stack.Count - 1;

        int value = stack[index];
        stack.RemoveAt(index);

        return value;
    }

    public int? Peek() {
        if (stack.Count == 0) return null;

        return stack[stack.Count - 1];
    }
}
