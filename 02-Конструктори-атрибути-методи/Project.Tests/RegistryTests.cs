namespace Project.Tests;

public class RegistryTests {
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(10)]
    public void Constructor_InstancesAreRegistered(int count) {
        List<Registry> instances = new();
        for (int i = 0; i < count; i++) {
            instances.Add(new Registry(i.ToString()));
        }

        IEnumerable<Registry> actual = Registry.All();

        foreach(var expected in instances) {
            Assert.That(actual, Does.Contain(expected));
        }
    }

    [TestCase("test")]
    [TestCase("reg")]
    [TestCase("other")]
    public void Find_ReturnsInstanceWhenRegistered(string name) {
        Registry r = new Registry(name);

        Registry? found = Registry.Find(name);

        Assert.That(found, Is.Not.Null);
        Assert.That(found, Is.EqualTo(r));
    }

    public void Clear_RemovesAllInstances() {
        Registry r = new("test");
        Registry r2 = new("test2");
        Registry r3 = new("test3");

        Registry.Clear();

        IEnumerable<Registry> instances = Registry.All();

        Assert.That(instances.Count(), Is.EqualTo(0));
    }
}