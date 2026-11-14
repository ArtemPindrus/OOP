namespace Project;

public class Inventory {
    private readonly List<Item> items = [];

    public IEnumerable<Item> Items => items;

    public int TotalWeight => items.Aggregate(0, (acc, item) => acc + item.Weight);

    public Inventory Add(Item item) {
        items.Add(item);

        return this;
    }

    public Weapon? GetStrongestWeapon() {
        var weapons = Items.OfType<Weapon>();

        if (!weapons.Any()) return null;

        return weapons.MaxBy((w) => w.Damage);
    }
}