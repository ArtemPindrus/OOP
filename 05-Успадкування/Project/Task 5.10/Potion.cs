namespace Project;

public class Potion : Item {
    public int Healing { get; }

    public Potion(string name, int weight, int healing) : base(name, weight) {
        if (healing < 0) throw new ArgumentException("Argument can't be negative.", nameof(healing));

        Healing = healing;
    }
}
