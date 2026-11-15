using Project.Exceptions;

namespace Project;

public class Warrior : Character {
    public int Damage { get; }

    public Warrior(int damage) {
        ArgumentNegativeException.ThrowIfNegative(damage);

        Damage = damage;
    }

    public override int Attack() => Damage;
}
