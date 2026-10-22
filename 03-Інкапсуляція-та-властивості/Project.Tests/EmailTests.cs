namespace Project.Tests;

[TestFixture]
public class EmailTests {
    [Test]
    public void Constructor_WithValidEmail_SetsAddress() {
        // Arrange & Act
        var email = new Email("user@example.com");

        // Assert
        Assert.That(email.Address, Is.EqualTo("user@example.com"));
    }

    [Test]
    public void Constructor_WithInvalidEmail_ThrowsArgumentException() {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Email("invalid-email"));
    }

    [Test]
    public void Address_SetWithValidEmail_UpdatesAddress() {
        // Arrange
        var email = new Email("user@example.com");

        // Act
        email.Address = "newuser@domain.org";

        // Assert
        Assert.That(email.Address, Is.EqualTo("newuser@domain.org"));
    }

    [Test]
    public void Address_SetWithMissingAt_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "userexample.com");
    }

    [Test]
    public void Address_SetWithMultipleAt_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "user@@example.com");
    }

    [Test]
    public void Address_SetWithEmptyUserPart_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "@example.com");
    }

    [Test]
    public void Address_SetWithEmptyDomainPart_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "user@");
    }

    [Test]
    public void Address_SetWithMissingDot_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "user@domain");
    }

    [Test]
    public void Address_SetWithWhitespace_ThrowsArgumentException() {
        // Arrange
        var email = new Email("user@example.com");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => email.Address = "user @example.com");
    }

    [Test]
    public void User_ReturnsPartBeforeAt() {
        // Arrange
        var email = new Email("testuser@example.com");

        // Act
        var user = email.User;

        // Assert
        Assert.That(user, Is.EqualTo("testuser"));
    }

    [Test]
    public void User_WithComplexUsername_ReturnsCorrectPart() {
        // Arrange
        var email = new Email("first.last@example.com");

        // Act
        var user = email.User;

        // Assert
        Assert.That(user, Is.EqualTo("first.last"));
    }

    [Test]
    public void Domain_ReturnsPartAfterAt() {
        // Arrange
        var email = new Email("user@example.com");

        // Act
        var domain = email.Domain;

        // Assert
        Assert.That(domain, Is.EqualTo("example.com"));
    }

    [Test]
    public void Domain_WithSubdomain_ReturnsCorrectPart() {
        // Arrange
        var email = new Email("user@mail.example.co.uk");

        // Act
        var domain = email.Domain;

        // Assert
        Assert.That(domain, Is.EqualTo("mail.example.co.uk"));
    }

    [Test]
    public void Address_SetWithValidComplexEmail_Succeeds() {
        // Arrange
        var email = new Email("user@example.com");

        // Act
        email.Address = "john.doe+tag@subdomain.example.org";

        // Assert
        Assert.That(email.Address, Is.EqualTo("john.doe+tag@subdomain.example.org"));
    }

    [Test]
    public void Address_SetWithNumbers_Succeeds() {
        // Arrange
        var email = new Email("user@example.com");

        // Act
        email.Address = "user123@example456.com";

        // Assert
        Assert.That(email.Address, Is.EqualTo("user123@example456.com"));
    }

    [Test]
    public void User_And_Domain_AreConsistent() {
        // Arrange
        var address = "user@example.com";
        var email = new Email(address);

        // Act
        var reconstructed = $"{email.User}@{email.Domain}";

        // Assert
        Assert.That(reconstructed, Is.EqualTo(address));
    }
}