namespace Project.Tests;

public class PizzaTests {
    [Test]
    public void Constructor_ThrowsIfSizeLessThanZero() {
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Pizza p = new(-1);
        });

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Pizza p = new(0);
        });
    }

    [TestCase(10, 1000)]
    [TestCase(12, 1200)]
    [TestCase(1, 100)]
    public void Price_IsCorrectWithoutToppings(int size, int expected) {
        Pizza p = new(size);

        int actual = p.Price();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(10, 2, 1020)]
    [TestCase(10, 5, 1050)]
    [TestCase(1, 5, 150)]
    [TestCase(1, 10, 200)]
    public void Price_IsCorrectWithToppings(int size, int toppingsCount, int expected) {
        Pizza p = new(size);
        for (int i = 0; i < toppingsCount; i++) {
            p.Add(Topping.Cheese); // kind of topping doesn't matter
        }

        int actual = p.Price();

        Assert.That(actual, Is.EqualTo(expected));
    }
}