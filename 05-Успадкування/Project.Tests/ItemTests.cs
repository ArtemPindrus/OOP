namespace Project.Tests;

public class ItemTests {
    [Fact]
    public void Cant_create_item_with_negative_weight() {
        Assert.Throws<ArgumentException>(() => new Item("bob", weight: -10));
    }
}

public class InventoryTests {
    [Fact]
    public void TotalWeight_returns_correct_value() {
        Inventory sut = new();

        sut.Add(new Item("", 10)).Add(new Item("", 2)).Add(new Item("", 3));

        Assert.Equal(15, sut.TotalWeight);
    }

    [Fact]
    public void GetStrongestWeapon_returns_correct_weapon() {
        Inventory sut = new();
        string name = "";
        int weight = 10;
        Weapon w1 = new(name, weight, 0);
        Weapon w2 = new(name, weight, 10);
        Weapon w3 = new(name, weight, 3);

        sut.Add(w1).Add(w2).Add(w3);

        Assert.Equal(w2, sut.GetStrongestWeapon());
    }
}