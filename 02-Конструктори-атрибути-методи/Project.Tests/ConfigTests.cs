namespace Project.Tests;

public class ConfigTests {
    [Test]
    public void Get_ReturnsDefaultValue_WhenKeyIsNotSet() {
        // Arrange
        const string key = "key1";
        const string expected = "default1";
        Config.SetDefault(key, expected);
        var config = new Config();

        // Act
        var result = config.Get(key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Get_ReturnsSetValue_WhenKeyIsSet() {
        // Arrange
        const string key = "key1";
        const string expected = "value1";
        Config.SetDefault(key, "default1");

        var config = new Config();
        config.Set(key, expected);

        // Act
        var result = config.Get(key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}