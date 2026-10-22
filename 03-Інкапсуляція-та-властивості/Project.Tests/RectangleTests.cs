using NUnit.Framework;
using Project;

namespace Project.Tests;

[TestFixture]
public class RectangleTests {
    private Rectangle _rectangle;

    [SetUp]
    public void SetUp() {
        _rectangle = new Rectangle(5f, 3f);
    }

    #region Constructor Tests
    [Test]
    public void Constructor_WithValidDimensions_CreatesRectangle() {
        // Arrange & Act
        var rect = new Rectangle(10f, 20f);

        // Assert
        Assert.That(rect.Width, Is.EqualTo(10f));
        Assert.That(rect.Height, Is.EqualTo(20f));
    }

    [Test]
    public void Constructor_WithZeroDimensions_CreatesRectangle() {
        // Arrange & Act
        var rect = new Rectangle(0f, 0f);

        // Assert
        Assert.That(rect.Width, Is.EqualTo(0f));
        Assert.That(rect.Height, Is.EqualTo(0f));
    }

    [Test]
    public void Constructor_WithNegativeWidth_ThrowsArgumentException() {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(-5f, 10f));
    }

    [Test]
    public void Constructor_WithNegativeHeight_ThrowsArgumentException() {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(5f, -10f));
    }
    #endregion

    #region Width Property Tests
    [Test]
    public void Width_SetValidPositiveValue_UpdatesWidth() {
        // Arrange & Act
        _rectangle.Width = 15f;

        // Assert
        Assert.That(_rectangle.Width, Is.EqualTo(15f));
    }

    [Test]
    public void Width_SetZero_UpdatesWidth() {
        // Arrange & Act
        _rectangle.Width = 0f;

        // Assert
        Assert.That(_rectangle.Width, Is.EqualTo(0f));
    }

    [Test]
    public void Width_SetNegativeValue_ThrowsArgumentException() {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => _rectangle.Width = -5f);
    }
    #endregion

    #region Height Property Tests
    [Test]
    public void Height_SetValidPositiveValue_UpdatesHeight() {
        // Arrange & Act
        _rectangle.Height = 12f;

        // Assert
        Assert.That(_rectangle.Height, Is.EqualTo(12f));
    }

    [Test]
    public void Height_SetZero_UpdatesHeight() {
        // Arrange & Act
        _rectangle.Height = 0f;

        // Assert
        Assert.That(_rectangle.Height, Is.EqualTo(0f));
    }

    [Test]
    public void Height_SetNegativeValue_ThrowsArgumentException() {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => _rectangle.Height = -5f);
    }
    #endregion

    #region Area Property Tests
    [Test]
    public void Area_WithValidDimensions_CalculatesCorrectly() {
        // Arrange & Act & Assert
        Assert.That(_rectangle.Area, Is.EqualTo(15f)); // 5 * 3
    }

    [Test]
    public void Area_WithZeroDimensions_ReturnsZero() {
        // Arrange
        var rect = new Rectangle(0f, 0f);

        // Act & Assert
        Assert.That(rect.Area, Is.EqualTo(0f));
    }

    [Test]
    public void Area_AfterChangingDimensions_UpdatesCorrectly() {
        // Arrange
        _rectangle.Width = 10f;
        _rectangle.Height = 4f;

        // Act & Assert
        Assert.That(_rectangle.Area, Is.EqualTo(40f)); // 10 * 4
    }

    [Test]
    public void Area_WithLargeDimensions_CalculatesCorrectly() {
        // Arrange
        var rect = new Rectangle(100f, 50f);

        // Act & Assert
        Assert.That(rect.Area, Is.EqualTo(5000f)); // 100 * 50
    }
    #endregion

    #region Perimeter Property Tests
    [Test]
    public void Perimeter_WithValidDimensions_CalculatesCorrectly() {
        // Arrange & Act & Assert
        Assert.That(_rectangle.Perimeter, Is.EqualTo(16f)); // (5 + 3) * 2
    }

    [Test]
    public void Perimeter_WithZeroDimensions_ReturnsZero() {
        // Arrange
        var rect = new Rectangle(0f, 0f);

        // Act & Assert
        Assert.That(rect.Perimeter, Is.EqualTo(0f));
    }

    [Test]
    public void Perimeter_AfterChangingDimensions_UpdatesCorrectly() {
        // Arrange
        _rectangle.Width = 8f;
        _rectangle.Height = 6f;

        // Act & Assert
        Assert.That(_rectangle.Perimeter, Is.EqualTo(28f)); // (8 + 6) * 2
    }

    [Test]
    public void Perimeter_WithLargeDimensions_CalculatesCorrectly() {
        // Arrange
        var rect = new Rectangle(100f, 50f);

        // Act & Assert
        Assert.That(rect.Perimeter, Is.EqualTo(300f)); // (100 + 50) * 2
    }
    #endregion

    #region Edge Cases
    [Test]
    public void Rectangle_WithDecimalValues_WorksCorrectly() {
        // Arrange & Act
        var rect = new Rectangle(2.5f, 3.7f);

        // Assert
        Assert.That(rect.Area, Is.EqualTo(2.5f * 3.7f).Within(0.001f));
        Assert.That(rect.Perimeter, Is.EqualTo((2.5f + 3.7f) * 2).Within(0.001f));
    }

    [Test]
    [TestCase(1f, 1f, 1f, 4f)]
    [TestCase(10f, 20f, 200f, 60f)]
    [TestCase(7.5f, 2.5f, 18.75f, 20f)]
    public void Rectangle_WithVariousDimensions_CalculatesCorrectly(float width, float height, float expectedArea, float expectedPerimeter) {
        // Arrange & Act
        var rect = new Rectangle(width, height);

        // Assert
        Assert.That(rect.Area, Is.EqualTo(expectedArea).Within(0.001f));
        Assert.That(rect.Perimeter, Is.EqualTo(expectedPerimeter).Within(0.001f));
    }
    #endregion
}