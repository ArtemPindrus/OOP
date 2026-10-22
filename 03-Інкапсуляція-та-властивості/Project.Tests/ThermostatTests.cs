using NUnit.Framework;

namespace Project.Tests {
    [TestFixture]
    public class ThermostatTests {
        [Test]
        public void Constructor_ValidParameters_InitializesCorrectly() {
            // Arrange & Act
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Assert
            Assert.That(thermostat.MinT, Is.EqualTo(15.0));
            Assert.That(thermostat.MaxT, Is.EqualTo(30.0));
            Assert.That(thermostat.Target, Is.EqualTo(22.0));
        }

        [Test]
        public void Constructor_MinTEqualMaxT_Succeeds() {
            // Arrange & Act
            var thermostat = new Thermostat(20.0, 20.0, 20.0);

            // Assert
            Assert.That(thermostat.MinT, Is.EqualTo(20.0));
            Assert.That(thermostat.MaxT, Is.EqualTo(20.0));
            Assert.That(thermostat.Target, Is.EqualTo(20.0));
        }

        [Test]
        public void Constructor_MinTGreaterThanMaxT_ThrowsArgumentException() {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Thermostat(30.0, 15.0, 22.0));
        }

        [Test]
        public void Constructor_MinTGreaterThanMaxT_ExceptionMessageIsCorrect() {
            // Arrange, Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Thermostat(30.0, 15.0, 22.0));
            Assert.That(ex.Message, Does.Contain("minT").And.Contain("maxT"));
        }

        [Test]
        public void Target_SetWithinRange_UpdatesValue() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act
            thermostat.Target = 25.0;

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(25.0));
        }

        [Test]
        public void Target_SetBelowMinT_ClampsToMinT() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act
            thermostat.Target = 10.0;

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(15.0));
        }

        [Test]
        public void Target_SetAboveMaxT_ClampsToMaxT() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act
            thermostat.Target = 35.0;

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(30.0));
        }

        [Test]
        public void Target_SetToMinT_Succeeds() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act
            thermostat.Target = 15.0;

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(15.0));
        }

        [Test]
        public void Target_SetToMaxT_Succeeds() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act
            thermostat.Target = 30.0;

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(30.0));
        }

        [Test]
        public void HeatingNeeded_CurrentBelowTarget_ReturnsTrue() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(20.0), Is.True);
        }

        [Test]
        public void HeatingNeeded_CurrentEqualTarget_ReturnsFalse() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(22.0), Is.False);
        }

        [Test]
        public void HeatingNeeded_CurrentAboveTarget_ReturnsFalse() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(25.0), Is.False);
        }

        [Test]
        public void HeatingNeeded_CurrentAtMinT_ReturnsTrue() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(15.0), Is.True);
        }

        [Test]
        public void HeatingNeeded_CurrentAtMaxT_ReturnsExpectedResult() {
            // Arrange
            var thermostat = new Thermostat(15.0, 30.0, 22.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(30.0), Is.False);
        }

        [Test]
        public void HeatingNeeded_NegativeTemperatures_WorksCorrectly() {
            // Arrange
            var thermostat = new Thermostat(-10.0, 10.0, 0.0);

            // Act & Assert
            Assert.That(thermostat.HeatingNeeded(-5.0), Is.True);
            Assert.That(thermostat.HeatingNeeded(0.0), Is.False);
            Assert.That(thermostat.HeatingNeeded(5.0), Is.False);
        }

        [Test]
        public void Target_ClampsOnConstructor_WhenBelowMinT() {
            // Arrange & Act
            var thermostat = new Thermostat(15.0, 30.0, 10.0);

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(15.0));
        }

        [Test]
        public void Target_ClampsOnConstructor_WhenAboveMaxT() {
            // Arrange & Act
            var thermostat = new Thermostat(15.0, 30.0, 35.0);

            // Assert
            Assert.That(thermostat.Target, Is.EqualTo(30.0));
        }
    }
}