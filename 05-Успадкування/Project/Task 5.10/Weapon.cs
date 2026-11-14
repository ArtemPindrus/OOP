namespace Project;

public class Weapon : Item {
    public int Damage { get; }

    public Weapon(string name, int weight, int damage) : base(name, weight) {
        if (damage < 0) throw new ArgumentException("Argument can't be negative.", nameof(damage));

        Damage = damage;
    }
}
