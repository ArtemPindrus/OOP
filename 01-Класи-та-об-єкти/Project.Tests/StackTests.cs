namespace Project.Tests {
    public class StackTests {
        [Test]
        public void Pop_ReturnsNull_WhenStackIsEmpty() {
            // Arrange
            Stack stack = new();

            // Act
            int? result = stack.Pop();

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Peek_ReturnsNull_WhenStackIsEmpty() {
            // Arrange
            Stack stack = new();

            // Act
            int? result = stack.Peek();

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Pop_ReturnsLastPushedValue() {
            // Arrange
            Stack stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            int? result = stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}