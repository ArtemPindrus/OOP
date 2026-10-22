namespace Project.Tests {
    [TestFixture]
    public class CircleTests {
        private Circle _circle;

        [SetUp]
        public void SetUp() {
            _circle = new Circle(5.0);
        }

        [Test]
        public void Constructor_CalculatesAreaOnInitialization() {
            // Arrange & Act
            var circle = new Circle(5.0);

            // Assert
            Assert.That(circle.Area, Is.EqualTo(2 * System.Math.PI * 5.0).Within(0.0001));
        }

        [Test]
        public void Constructor_SetsComputeCountToOne() {
            // Arrange & Act
            var circle = new Circle(5.0);

            // Assert
            Assert.That(circle.ComputeCount, Is.EqualTo(1));
        }

        [Test]
        public void Radius_WhenSet_UpdatesArea() {
            // Arrange
            var newRadius = 10.0;
            var expectedArea = 2 * System.Math.PI * newRadius;

            // Act
            _circle.Radius = newRadius;

            // Assert
            Assert.That(_circle.Area, Is.EqualTo(expectedArea).Within(0.0001));
        }

        [Test]
        public void Radius_WhenSet_IncrementsComputeCount() {
            // Arrange
            var initialCount = _circle.ComputeCount;

            // Act
            _circle.Radius = 8.0;

            // Assert
            Assert.That(_circle.ComputeCount, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void Radius_MultipleChanges_IncrementsComputeCountEachTime() {
            // Arrange
            var initialCount = _circle.ComputeCount;

            // Act
            _circle.Radius = 7.0;
            _circle.Radius = 12.0;
            _circle.Radius = 3.5;

            // Assert
            Assert.That(_circle.ComputeCount, Is.EqualTo(initialCount + 3));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(1.0)]
        [TestCase(100.5)]
        public void Radius_SetWithVariousValues_CalculatesAreaCorrectly(double radius) {
            // Arrange
            var expectedArea = 2 * System.Math.PI * radius;

            // Act
            _circle.Radius = radius;

            // Assert
            Assert.That(_circle.Area, Is.EqualTo(expectedArea).Within(0.0001));
        }
    }
}