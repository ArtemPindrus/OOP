namespace Project.Tests {
    public class ProductTests {
        [Test]
        public void Constructor_WhenDiscountIsOutOfRange_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            string name = "Test Product";
            double price = 100.0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(name, price, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(name, price, -10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(name, price, 110));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(name, price, 101));
        }

        [TestCase(100.0, 20, 80.0)]
        [TestCase(50.0, 10, 45.0)]
        [TestCase(200.0, 50, 100.0)]
        public void GetFinalPrice_ShouldReturnCorrectPrice_WhenDiscountIsApplied(double price, int discount, double expected) {
            // Arrange
            var product = new Product("Test Product", price, discount);

            // Act
            double finalPrice = product.GetFinalPrice();

            // Assert
            Assert.That(finalPrice, Is.EqualTo(expected).Within(0.01));
        }

        [Test]
        public void Test_WhenQuantityIsNegative_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            var product = new Product("Test Product", 100.0, 20);
            int negativeQuantity = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Total(negativeQuantity));
        }

        [Test]
        public void Total_ShouldReturnCorrectTotalPrice_WhenQuantityIsProvided() {
            // Arrange
            var product = new Product("Test Product", 100.0, 20);
            int quantity = 5;
            double expectedTotal = 400.0; // 80 * 5

            // Act
            double totalPrice = product.Total(quantity);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(expectedTotal).Within(0.01));
        }
    }
}