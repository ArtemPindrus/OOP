namespace Project.Tests;

public class PersonTests {
    [Fact]
    public void Cant_create_person_with_negative_age() {
        Assert.Throws<ArgumentException>(() => new Person("Bob", -10));
    }
}