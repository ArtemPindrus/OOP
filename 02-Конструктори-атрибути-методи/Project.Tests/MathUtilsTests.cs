namespace Project.Tests;

public class MathUtilsTests {
    [TestCase(0,0,0)]
    [TestCase(1,5,1)]
    [TestCase(10,5,5)]
    public void GCD_ReturnsCorrectValue(int a, int b, int expected) {
        Assert.That(MathUtils.GCD(a,b), Is.EqualTo(expected));
    }
    
    [TestCase(1, false)]
    [TestCase(4, false)]
    [TestCase(6, false)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(10, false)]
    [TestCase(0, false)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(5, true)]
    [TestCase(7, true)]
    [TestCase(11, true)]
    public void IsPrime_ReturnsCorrectValue(int number, bool expected) {
        Assert.That(MathUtils.IsPrime(number), Is.EqualTo(expected));
    }

    [TestCase(0,1)]
    [TestCase(1,1)]
    [TestCase(2,2)]
    [TestCase(3,6)]
    [TestCase(4,24)]
    public void Factorial_ReturnsCorrectValue(int number, int expected) {
        Assert.That(MathUtils.Factorial(number), Is.EqualTo(expected));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    [TestCase(6, 8)]
    [TestCase(7, 13)]
    public void Fibonacci_ReturnsCorrectValue(int number, int expected) {
        Assert.That(MathUtils.Fibonacci(number), Is.EqualTo(expected));
    }
}