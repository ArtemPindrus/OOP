using Project.Exceptions;

namespace Project.Tests;

public static class TestingUtils {
    extension(Assert) {
        public static void ThrowsArgumentNegativeException(Action a, string argumentName) {
            ArgumentNegativeException e =
                Assert.Throws<ArgumentNegativeException>(a);
            Assert.Equal(argumentName, e.ArgumentName);
        }
    }
}