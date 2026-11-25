using Project.Exceptions;

namespace Project;

public class Attacker : Component {
    public int Damage { get; }

    public Attacker(int damage) {
        ArgumentNegativeException.ThrowIfNegative(damage);

        Damage = damage;
    }
}
