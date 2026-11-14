namespace Project.Tests;

public class ArmorTests {
    [Fact]
    public void Cant_create_armor_with_negative_defense() {
        Assert.Throws<ArgumentException>(() => new Armor("bob", 10, defense: -10));
    }
}
