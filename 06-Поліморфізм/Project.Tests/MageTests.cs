using Project.Exceptions;

namespace Project.Tests;

public class MageTests {
    [Fact]
    public void Cant_create_mage_with_negative_damage() {
        Assert.Throws<ArgumentNegativeException>(() => new Mage(magicDamage: -10, 0.5f, 10));
    }

    [Fact]
    public void Cant_create_mage_with_negative_mana() {
        Assert.Throws<ArgumentNegativeException>(() => new Mage(magicDamage: 1, 0.5f, mana: -10));
    }

    [Fact]
    public void Cant_create_mage_with_weakness_multiplier_out_of_range() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Mage(magicDamage: 1, 1.1f, mana: 10));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Mage(magicDamage: 1, -1f, mana: 10));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Mage(magicDamage: 1, 10f, mana: 10));
    }

    [Fact]
    public void Deals_weak_damage_after_expanding_mana() {
        int mana = 3;
        float multiplier = 0.5f;
        int damage = 10;
        int weakDamage = 5;
        Mage m = new(damage, multiplier, mana);

        int availableStrongAttacks = mana / Mage.ManaCost;
        for (int i = 0; i < availableStrongAttacks; i++) {
            Assert.Equal(damage, m.Attack());
        }

        Assert.Equal(weakDamage, m.Attack());
    }
}