namespace Project.Tests;

public class TicketTests {
    [SetUp]
    public void SetUp() {
        typeof(Ticket)?.GetProperty(nameof(Ticket.Created))?.SetValue(null, 0);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(100)]
    [TestCase(120)]
    public void Created_ReturnsAmountOfInstances(int count) {
        for (int i = 0; i < count; i++) {
            Ticket t = new();
        }

        Assert.That(Ticket.Created, Is.EqualTo(count));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(100)]
    [TestCase(120)]
    public void Constructor_IdSetToInstanceCount(int count) {
        for (int i = 0; i < count; i++) {
            Ticket t = new();

            Assert.That(t.Id, Is.EqualTo(i + 1));
        }
    }
}