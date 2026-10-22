using NUnit.Framework;
using Project;

namespace Project.Tests;

[TestFixture]
public class PersonTests {
    [Test]
    public void Constructor_WithValidNameAndAge_CreatesPersonSuccessfully() {
        // Arrange & Act
        var person = new Person("John Doe", 30);

        // Assert
        Assert.That(person.Name, Is.EqualTo("John Doe"));
        Assert.That(person.Age, Is.EqualTo(30));
    }

    [Test]
    public void Constructor_TrimsWhitespaceName() {
        // Arrange & Act
        var person = new Person("  Alice  ", 25);

        // Assert
        Assert.That(person.Name, Is.EqualTo("Alice"));
    }

    #region Name Property Tests

    [Test]
    public void Name_SetValidName_UpdatesSuccessfully() {
        // Arrange
        var person = new Person("John", 30);

        // Act
        person.Name = "Jane";

        // Assert
        Assert.That(person.Name, Is.EqualTo("Jane"));
    }

    [Test]
    public void Name_SetNameWithLeadingAndTrailingWhitespace_Trims() {
        // Arrange
        var person = new Person("John", 30);

        // Act
        person.Name = "  Bob  ";

        // Assert
        Assert.That(person.Name, Is.EqualTo("Bob"));
    }

    [Test]
    public void Name_SetNull_ThrowsArgumentException() {
        // Arrange
        var person = new Person("John", 30);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => person.Name = null!);
    }

    [Test]
    public void Name_SetEmptyString_ThrowsArgumentException() {
        // Arrange
        var person = new Person("John", 30);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => person.Name = "");
        Assert.That(ex.Message, Contains.Substring("Name should be non-empty."));
    }

    [Test]
    public void Name_SetWhitespaceOnly_ThrowsArgumentException() {
        // Arrange
        var person = new Person("John", 30);

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => person.Name = "   ");
        Assert.That(ex.Message, Contains.Substring("Name should be non-empty."));
    }

    #endregion

    #region Age Property Tests

    [Test]
    public void Age_SetValidAge_UpdatesSuccessfully() {
        // Arrange
        var person = new Person("John", 25);

        // Act
        person.Age = 40;

        // Assert
        Assert.That(person.Age, Is.EqualTo(40));
    }

    [Test]
    public void Age_SetToZero_Succeeds() {
        // Arrange
        var person = new Person("John", 25);

        // Act
        person.Age = 0;

        // Assert
        Assert.That(person.Age, Is.EqualTo(0));
    }

    [Test]
    public void Age_SetTo150_Succeeds() {
        // Arrange
        var person = new Person("John", 25);

        // Act
        person.Age = 150;

        // Assert
        Assert.That(person.Age, Is.EqualTo(150));
    }

    [Test]
    public void Age_SetToNegativeValue_ThrowsArgumentOutOfRangeException() {
        // Arrange
        var person = new Person("John", 25);

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => person.Age = -1);
    }

    [Test]
    public void Age_SetAbove150_ThrowsArgumentOutOfRangeException() {
        // Arrange
        var person = new Person("John", 25);

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => person.Age = 151);
    }

    #endregion

    #region IsAdult Property Tests

    [Test]
    [TestCase(0, false)]
    [TestCase(17, false)]
    [TestCase(18, true)]
    [TestCase(25, true)]
    [TestCase(150, true)]
    public void IsAdult_ReturnsCorrectValue(int age, bool expectedIsAdult) {
        // Arrange & Act
        var person = new Person("John", age);

        // Assert
        Assert.That(person.IsAdult, Is.EqualTo(expectedIsAdult));
    }
    #endregion
}