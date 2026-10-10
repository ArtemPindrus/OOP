namespace Project.Tests {
    public class PointTests {
        [TestCase(0, 0, 5, 6, 5, 6)]
        [TestCase(15, 10, -2, -3, 13, 7)]
        [TestCase(2, 3, -2, -3, 0, 0)]
        public void TestMove(int x, int y, int dx, int dy, int expectedX, int expectedY) {
            // Arrange
            Point point = new(x, y);

            // Act
            point.Move(dx, dy);

            // Assert
            Assert.Multiple(() => {
                Assert.That(point.X, Is.EqualTo(expectedX));
                Assert.That(point.Y, Is.EqualTo(expectedY));
            });
        }

        [TestCase(0, 0, true)]
        [TestCase(0, 5, false)]
        [TestCase(5, 0, false)]
        public void IsOrigin_ReturnsTrue_WhenPointIsAtOrigin(int x, int y, bool expected) {
            // Arrange
            Point point = new(x, y);

            // Act
            bool result = point.IsOrigin();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 0, 3, 4, 5)]
        [TestCase(1, 1, 4, 5, 5)]
        [TestCase(0, 0, 1, 0, 1)]
        [TestCase(-3, -4, 0, 0, 5)]
        [TestCase(1, 2, 4, 6, 5)]
        public void DistanceTo_ReturnsCorrectDistance(int x1, int y1, int x2, int y2, double expected) {
            // Arrange
            Point point1 = new(x1, y1);
            Point point2 = new(x2, y2);

            // Act
            double result = point1.DistanceTo(point2);

            // Assert
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
