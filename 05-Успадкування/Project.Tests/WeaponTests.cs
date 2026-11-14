namespace Project.Tests;

public class WeaponTests {
    [Fact]
    public void Cant_create_weapon_with_negative_damage() {
        Assert.Throws<ArgumentException>(() => new Weapon("bob", 10, damage: -10));
    }
}