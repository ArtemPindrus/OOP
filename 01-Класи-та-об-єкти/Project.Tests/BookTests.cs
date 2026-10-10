namespace Project.Tests {
    [TestFixture]
    public class BookTests {
        [Test]
        public void Constructor_WithNegativeCurrentPage_ThrowsArgumentException() {
            Assert.Throws<ArgumentException>(() => new Book("Test Book", "Author", 300, -10));
        }

        [Test]
        public void Constructor_WithNegativePages_ThrowsArgumentException() {
            Assert.Throws<ArgumentException>(() => new Book("Test Book", "Author", -1, 0));
        }

        [Test]
        public void Constructor_WithCurrentPageGreaterThanPages_ClampsToPages() {
            // Arrange & Act
            var book = new Book("Test Book", "Author", 300, 500);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(300));
        }

        [Test]
        public void Constructor_WithZeroCurrentPage_SetsToZero() {
            // Arrange & Act
            var book = new Book("Test Book", "Author", 200, 0);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(0));
        }

        [Test]
        public void Read_WithPositivePages_IncrementsCurrentPage() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 50);

            // Act
            book.Read(30);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(80));
        }

        [Test]
        public void Read_WithMultipleCalls_AccumulatesPages() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 0);

            // Act
            book.Read(50);
            book.Read(75);
            book.Read(25);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(150));
        }

        [Test]
        public void Read_ExceedingTotalPages_ClampsToPages() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 250);

            // Act
            book.Read(100);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(300));
        }

        [Test]
        public void Read_WithNegativePages_ThrowsArgumentException() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 100);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => book.Read(-30));
        }

        [Test]
        public void Read_WithZeroPages_DoesNotChangeCurrentPage() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 100);

            // Act
            book.Read(0);

            // Assert
            Assert.That(book.CurrentPage, Is.EqualTo(100));
        }

        [TestCase(0, 10, 0.0)]
        [TestCase(10, 10, 100.0)]
        [TestCase(5, 10, 50.0)]
        [TestCase(1, 10, 10.0)]
        [TestCase(25, 100, 25.0)]
        [TestCase(75, 300, 25.0)]
        [TestCase(3, 4, 75.0)]
        public void GetProgressPercentage_WithVariousValues_CalculatesCorrectly(int currentPage, int totalPages, double expectedPercentage) {
            // Arrange
            var book = new Book("Test Book", "Author", totalPages, currentPage);

            // Act
            var progress = book.GetProgressPercentage();

            // Assert
            Assert.That(progress, Is.EqualTo(expectedPercentage));
        }

        // IsFinished Tests
        [Test]
        public void IsFinished_WhenCurrentPageEqualsPages_ReturnsTrue() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 300);

            // Act
            var isFinished = book.IsFinished();

            // Assert
            Assert.That(isFinished, Is.True);
        }

        [Test]
        public void IsFinished_WhenCurrentPageLessThanPages_ReturnsFalse() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 250);

            // Act
            var isFinished = book.IsFinished();

            // Assert
            Assert.That(isFinished, Is.False);
        }

        [Test]
        public void IsFinished_AtStart_ReturnsFalse() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 0);

            // Act
            var isFinished = book.IsFinished();

            // Assert
            Assert.That(isFinished, Is.False);
        }

        [Test]
        public void IsFinished_AfterReadingAllPages_ReturnsTrue() {
            // Arrange
            var book = new Book("Test Book", "Author", 300, 100);

            // Act
            book.Read(200);
            var isFinished = book.IsFinished();

            // Assert
            Assert.That(isFinished, Is.True);
        }
    }
}