using NUnit.Framework;
using Project;

namespace ProjectTests;

[TestFixture]
public class InventoryTests {
    private Inventory inventory;

    [SetUp]
    public void Setup() {
        inventory = new Inventory();
    }

    #region Add Tests
    [Test]
    public void Add_SingleItemNewName_AddsItemToInventory() {
        inventory.Add("Apple", 5);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(5));
    }

    [Test]
    public void Add_SingleItemExistingName_IncreasesQuantity() {
        inventory.Add("Apple", 5);
        inventory.Add("Apple", 3);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(8));
    }

    [Test]
    public void Add_ZeroQuantity_AddsItemWithZero() {
        inventory.Add("Apple", 0);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(0));
    }

    [Test]
    public void Add_MultipleItems_AllItemsPresent() {
        inventory.Add("Apple", 5)
            .Add("Banana", 3)
            .Add("Orange", 2);

        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(5));
        Assert.That(inventory.Quantity("Banana"), Is.EqualTo(3));
        Assert.That(inventory.Quantity("Orange"), Is.EqualTo(2));
    }

    [Test]
    public void Add_NegativeQuantity_ThrowsArgumentException() {
        var ex = Assert.Throws<ArgumentException>(() => inventory.Add("Apple", -5));

        Assert.That(ex.ParamName, Is.EqualTo("quantity"));
    }
    #endregion

    #region Remove Tests
    [Test]
    public void Remove_ExistingItemPartialQuantity_DecreasesQuantity() {
        inventory.Add("Apple", 10);
        inventory.Remove("Apple", 3);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(7));
    }

    [Test]
    public void Remove_ExistingItemAllQuantity_RemovesItemCompletely() {
        inventory.Add("Apple", 5);
        inventory.Remove("Apple", 5);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(0));
    }

    [Test]
    public void Remove_NonExistentItem_ThrowsArgumentException() {
        var ex = Assert.Throws<ArgumentException>(() => inventory.Remove("Apple", 1));

        Assert.That(ex.ParamName, Is.EqualTo("name"));
    }

    [Test]
    public void Remove_MoreThanAvailable_ThrowsInvalidOperationException() {
        inventory.Add("Apple", 5);
        var ex = Assert.Throws<InvalidOperationException>(() => inventory.Remove("Apple", 10));
    }

    [Test]
    public void Remove_NegativeQuantity_ThrowsArgumentException() {
        inventory.Add("Apple", 5);
        var ex = Assert.Throws<ArgumentException>(() => inventory.Remove("Apple", -3));
        Assert.That(ex.ParamName, Is.EqualTo("quantity"));
    }

    [Test]
    public void Remove_ZeroQuantity_DoesNotChangeStock() {
        inventory.Add("Apple", 5);
        inventory.Remove("Apple", 0);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(5));
    }
    #endregion

    #region Quantity Tests
    [Test]
    public void Quantity_ItemNotInStock_ReturnsZero() {
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(0));
    }

    [Test]
    public void Quantity_ExistingItem_ReturnsCorrectQuantity() {
        inventory.Add("Apple", 7);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(7));
    }

    [Test]
    public void Quantity_MultipleItems_ReturnsCorrectQuantityForEach() {
        inventory.Add("Apple", 5).Add("Banana", 3);
        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(5));
        Assert.That(inventory.Quantity("Banana"), Is.EqualTo(3));
        Assert.That(inventory.Quantity("Orange"), Is.EqualTo(0));
    }
    #endregion

    #region Items Property Tests
    [Test]
    public void Items_EmptyInventory_ReturnsEmptyDictionary() {
        Assert.That(inventory.Items, Is.Empty);
    }

    [Test]
    public void Items_ReturnsAllItems() {
        inventory.Add("Apple", 5).Add("Banana", 3).Add("Orange", 2);
        var items = inventory.Items;

        Assert.That(items.Count, Is.EqualTo(3));
        Assert.That(items["Apple"], Is.EqualTo(5));
        Assert.That(items["Banana"], Is.EqualTo(3));
        Assert.That(items["Orange"], Is.EqualTo(2));
    }

    [Test]
    public void Items_ReturnsCopy_NotReference() {
        inventory.Add("Apple", 5);
        var items = inventory.Items;
        items["Apple"] = 100;

        Assert.That(inventory.Quantity("Apple"), Is.EqualTo(5));
    }

    [Test]
    public void Items_ModifyingReturnedDictionary_DoesNotAffectInventory() {
        inventory.Add("Apple", 5);
        var items1 = inventory.Items;
        items1["Banana"] = 50;

        var items2 = inventory.Items;
        Assert.That(items2.ContainsKey("Banana"), Is.False);
    }
    #endregion
}