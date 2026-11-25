using Project.Exceptions;

namespace Project;

public class Health : Component {
    public int Max { get; }
    public int Current { get; private set; }
    public bool IsAlive => Current > 0;

    public Health(int max) {
        ArgumentNegativeException.ThrowIfNegative(max);

        Max = max;
        Current = max;
    }

    public void TakeDamage(int amount) {
        ArgumentNegativeException.ThrowIfNegative(amount);

        Current = Math.Max(0, Current - amount);
    }

    public override string ToString() => $"{Current}/{Max}";
}
