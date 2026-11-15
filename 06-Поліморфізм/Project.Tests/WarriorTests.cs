using Project.Exceptions;

namespace Project.Tests;

public class WarriorTests {
    [Fact]
    public void Cant_create_warrior_with_negative_damage() {
        Assert.Throws<ArgumentNegativeException>(() => new Warrior(damage: -10));
    }
}