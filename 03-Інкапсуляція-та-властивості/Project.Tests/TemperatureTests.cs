using NUnit.Framework;

namespace Project.Tests {
    [TestFixture]
    public class TemperatureTests {
        [Test]
        public void Constructor_WithValidCelsius_SetsTemperature() {
            // Arrange & Act
            var temp = new Temperature(25.0);

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(25.0));
        }

        [Test]
        public void Constructor_WithAbsoluteZero_SetsTemperature() {
            // Arrange & Act
            var temp = new Temperature(-273.15);

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(-273.15));
        }

        [Test]
        public void Constructor_BelowAbsoluteZero_ThrowsArgumentException() {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Temperature(-273.16));
        }

        [Test]
        public void Celsius_SetBelowAbsoluteZero_ThrowsArgumentException() {
            // Arrange
            var temp = new Temperature(0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => temp.Celsius = -273.16);
        }

        [Test]
        public void Celsius_SetToAbsoluteZero_Succeeds() {
            // Arrange
            var temp = new Temperature(25.0);

            // Act
            temp.Celsius = -273.15;

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(-273.15));
        }

        [Test]
        public void Fahrenheit_Get_ReturnsCorrectConversion() {
            // Arrange
            var temp = new Temperature(0);

            // Act
            double fahrenheit = temp.Fahrenheit;

            // Assert
            Assert.That(fahrenheit, Is.EqualTo(32.0));
        }

        [Test]
        public void Fahrenheit_GetWhenCelsiusIs100_ReturnsCorrectConversion() {
            // Arrange
            var temp = new Temperature(100.0);

            // Act
            double fahrenheit = temp.Fahrenheit;

            // Assert
            Assert.That(fahrenheit, Is.EqualTo(212.0));
        }

        [Test]
        public void Fahrenheit_Set_UpdatesCelsiusCorrectly() {
            // Arrange
            var temp = new Temperature(0);

            // Act
            temp.Fahrenheit = 32.0;

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(0.0).Within(0.0001));
        }

        [Test]
        public void Fahrenheit_SetTo212_UpdatesCelsiusTo100() {
            // Arrange
            var temp = new Temperature(0);

            // Act
            temp.Fahrenheit = 212.0;

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(100.0).Within(0.0001));
        }

        [Test]
        public void Fahrenheit_SetBelowAbsoluteZero_ThrowsArgumentException() {
            // Arrange
            var temp = new Temperature(0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => temp.Fahrenheit = -460.67); // Below absolute zero in Fahrenheit
        }

        [Test]
        public void Temperature_NegativeCelsius_Succeeds() {
            // Arrange & Act
            var temp = new Temperature(-40.0);

            // Assert
            Assert.That(temp.Celsius, Is.EqualTo(-40.0));
            Assert.That(temp.Fahrenheit, Is.EqualTo(-40.0)); // -40°C equals -40°F
        }
    }
}