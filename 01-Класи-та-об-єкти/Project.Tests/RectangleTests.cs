namespace Project.Tests {
    public class RectangleTests {
        [TestCase(-5, 10)]
        [TestCase(5, -10)]
        [TestCase(-5, -10)]
        public void IncorrectDimensionsFailConstruction(int width, int height) {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(width, height));
        }

        [TestCase(5, 10, 50)]
        [TestCase(3, 7, 21)]
        [TestCase(3, 10, 30)]
        public void CalculateAreaReturnsCorrectValue(int width, int height, int expectedArea) {
            // Arrange
            var rectangle = new Rectangle(width, height);

            // Act
            var area = rectangle.CalculateArea();

            // Assert
            Assert.That(area, Is.EqualTo(expectedArea));
        }

        [TestCase(5, 10, 30)]
        [TestCase(3, 7, 20)]
        [TestCase(3, 10, 26)]
        public void CalculatePerimeterReturnsCorrectValue(int width, int height, int expectedPerimeter) {
            // Arrange
            var rectangle = new Rectangle(width, height);

            // Act
            var perimeter = rectangle.CalculatePerimeter();

            // Assert
            Assert.That(perimeter, Is.EqualTo(expectedPerimeter));
        }

        [TestCase(5, 5, true)]
        [TestCase(12, 12, true)]
        [TestCase(5, 4, false)]
        public void IsSquareReturnsTrueForSquare(int width, int height, bool expectedIsSquare) {
            // Arrange
            var rectangle = new Rectangle(width, height);
            // Act
            var isSquare = rectangle.IsSquare();
            // Assert
            Assert.That(isSquare, Is.EqualTo(expectedIsSquare));
        }
    }
}
