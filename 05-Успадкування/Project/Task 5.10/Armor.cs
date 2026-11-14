namespace Project;

public class Armor : Item {
    public int Defense { get; }

    public Armor(string name, int weight, int defense) : base(name, weight) {
        if (defense < 0) throw new ArgumentException("Argument can't be negative.", nameof(defense));

        Defense = defense;
    }
}
