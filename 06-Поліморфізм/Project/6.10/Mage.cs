using Project.Exceptions;

namespace Project;

public class Mage : Character {
    /// <summary>
    /// Mana used per attack.
    /// </summary>
    public const int ManaCost = 1;

    public int MagicDamage { get; }

    /// <summary>
    /// <see cref="MagicDamage"/> multiplier when <see cref="Mana"/> is too low.
    /// </summary>
    public float WeaknessMultiplier { get; }

    public float Mana { 
        get;
        private set {
            ArgumentNegativeException.ThrowIfNegative(value);

            field = value;
        }
    }

    public Mage(int magicDamage, float weaknessMultiplier, float mana) {
        ArgumentNegativeException.ThrowIfNegative(magicDamage);
        ArgumentNegativeException.ThrowIfNegative(mana);
        if (weaknessMultiplier < 0 || weaknessMultiplier > 1)
            throw new ArgumentOutOfRangeException(nameof(weaknessMultiplier), "Argument should be in [0;1] range.");

        MagicDamage = magicDamage;
        WeaknessMultiplier = weaknessMultiplier;
        Mana = mana;
    }

    public override int Attack() {
        if (Mana >= ManaCost) {
            Mana--;
            return MagicDamage;
        }

        return (int)(MagicDamage * WeaknessMultiplier);
    }
}