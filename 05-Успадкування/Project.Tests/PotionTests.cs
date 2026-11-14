namespace Project.Tests;

public class PotionTests {
    [Fact]
    public void Cant_create_potion_with_negative_healing() {
        Assert.Throws<ArgumentException>(() => new Potion("bob", 10, healing: -10));
    }
}
