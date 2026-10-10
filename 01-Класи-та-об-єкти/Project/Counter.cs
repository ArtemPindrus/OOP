namespace Project;

public class Counter {
    public int Value { get; private set; }

    /// <summary>
    /// Creates a new Counter with the specified initial value.
    /// </summary>
    /// <param name="initialValue">The initial value for the counter.</param>
    /// <exception cref="ArgumentException">Initial value is negative.</exception>
    public Counter(int initialValue) {
        Value = initialValue;

        if (Value < 0) throw new ArgumentException("Initial value cannot be negative.", nameof(initialValue));
    }

    public void Increment() => Value++;

    public void Decrement() {
        if (Value > 0) Value--;
    }

    /// <summary>
    /// Resets the Counter to 0.
    /// </summary>
    public void Reset() {
        Value = 0;
    }
}
