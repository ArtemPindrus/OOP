using NUnit.Framework;
using System;

namespace Project.Tests {
    [TestFixture]
    public class PasswordTests {
        private Password _password;

        [SetUp]
        public void SetUp() {
            _password = new Password();
        }

        [Test]
        public void Set_WithValidPassword_StoresHashSuccessfully() {
            // Arrange
            string validPassword = "Password123";

            // Act & Assert - should not throw
            Assert.DoesNotThrow(() => _password.Set(validPassword));
        }

        [Test]
        public void Set_WithPasswordLessThan8Characters_ThrowsArgumentException() {
            // Arrange
            string shortPassword = "Pass123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _password.Set(shortPassword));
        }

        [Test]
        public void Set_WithExactly8Characters_StoresHashSuccessfully() {
            // Arrange
            string exactPassword = "Password";

            // Act & Assert - should not throw
            Assert.DoesNotThrow(() => _password.Set(exactPassword));
        }

        [Test]
        public void Set_WithEmptyString_ThrowsArgumentException() {
            // Arrange
            string emptyPassword = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _password.Set(emptyPassword));
        }

        [Test]
        public void Check_WithCorrectPassword_ReturnsTrue() {
            // Arrange
            string password = "SecurePass123";
            _password.Set(password);

            // Act
            bool result = _password.Check(password);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Check_WithIncorrectPassword_ReturnsFalse() {
            // Arrange
            string password = "SecurePass123";
            _password.Set(password);

            // Act
            bool result = _password.Check("DifferentPass123");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Check_WithSimilarButDifferentPassword_ReturnsFalse() {
            // Arrange
            string password = "Password123";
            _password.Set(password);

            // Act
            bool result = _password.Check("Password124");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Check_WithCaseSensitiveDifference_ReturnsFalse() {
            // Arrange
            string password = "SecurePass123";
            _password.Set(password);

            // Act
            bool result = _password.Check("securepass123");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Set_MultipleTimes_UpdatesHashEachTime() {
            // Arrange
            string password1 = "FirstPassword1";
            string password2 = "SecondPassword2";

            // Act
            _password.Set(password1);
            bool checkFirst = _password.Check(password1);

            _password.Set(password2);
            bool checkSecond = _password.Check(password2);
            bool checkFirstAfterUpdate = _password.Check(password1);

            // Assert
            Assert.That(checkFirst, Is.True);
            Assert.That(checkSecond, Is.True);
            Assert.That(checkFirstAfterUpdate, Is.False);
        }
    }
}