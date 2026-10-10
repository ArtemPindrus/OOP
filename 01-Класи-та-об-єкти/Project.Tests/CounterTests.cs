namespace Project.Tests {
    public class CounterTests {
        public void Construction_WithNegativeInitialValue_ThrowsArgumentException() {
            // Arrange
            int negativeInitialValue = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Counter(negativeInitialValue));
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(10, 11)]
        public void Increment_VariousValues(int initialValue, int expectedValue) {
            // Arrange
            Counter counter = new(initialValue);

            // Act
            counter.Increment();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Increment_MultipleIncrements() {
            // Arrange
            Counter counter = new(0);

            // Act
            counter.Increment();
            counter.Increment();
            counter.Increment();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(3));
        }

        [TestCase(1, 0)]
        [TestCase(5, 4)]
        [TestCase(10, 9)]
        [TestCase(100, 99)]
        public void Decrement_VariousValues(int initialValue, int expectedValue) {
            // Arrange
            Counter counter = new(initialValue);

            // Act
            counter.Decrement();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Decrement_WhenValueIsZero_DoesNotDecrement() {
            // Arrange
            Counter counter = new(0);

            // Act
            counter.Decrement();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(0));
        }

        [Test]
        public void Decrement_MultipleDecrements() {
            // Arrange
            Counter counter = new(5);

            // Act
            counter.Decrement();
            counter.Decrement();
            counter.Decrement();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(2));
        }

        [TestCase(5)]
        [TestCase(100)]
        [TestCase(0)]
        public void Reset_ResetsToZero(int initialValue) {
            // Arrange
            Counter counter = new(initialValue);

            // Act
            counter.Reset();

            // Assert
            Assert.That(counter.Value, Is.EqualTo(0));
        }
    }
}