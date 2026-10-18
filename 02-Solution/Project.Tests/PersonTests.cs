namespace Project.Tests;

public class PersonTests {
    [TestCase("Bob Ross", "Bob", "Ross")]
    [TestCase("Harvey Smith", "Harvey", "Smith")]
    [TestCase("Raphael Colantonio", "Raphael", "Colantonio")]
    public void FromFullName_CreatesCorrectInstance(string fullName, string firstName, string lastName) {
        Person person = Person.FromFullName(fullName);

        Assert.That(person.FirstName, Is.EqualTo(firstName));
        Assert.That(person.LastName, Is.EqualTo(lastName));
    }

    [TestCase("Bob", "Ross", "Bob Ross")]
    [TestCase("Harvey", "Smith", "Harvey Smith")]
    [TestCase("Raphael", "Colantonio", "Raphael Colantonio")]
    public void FullName_ReturnsCorrectString(string firstName, string lastName, string expected) {
        Person p = new(firstName, lastName);

        Assert.That(p.FullName(), Is.EqualTo(expected));
    }

    [TestCase("Bob Ross", "B. R.")]
    [TestCase("Harvey Smith", "H. S.")]
    [TestCase("Raphael Colantonio", "R. C.")]
    public void Initials_ReturnsCorrectString(string fullName, string expected) {
        Person p = Person.FromFullName(fullName);

        string actual = p.Initials();

        Assert.That(actual, Is.EqualTo(expected));
    }
}