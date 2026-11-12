namespace Project.Tests;

public class ComplexTests {
    [Fact]
    public void Equality_operator_returns_true_for_complex_numbers_with_the_same_values() {
        var a = new Complex(1, 2);
        var b = new Complex(1, 2);

        bool result = a == b;

        Assert.True(result);
    }

    [Fact]
    public void Addition_returns_correct_result() {
        var a = new Complex(1, 2);
        var b = new Complex(3, 4);
        Complex expected = new(4, 6);

        Complex result = a + b;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiplication_returns_correct_result() {
        var a = new Complex(3, 2);
        var b = new Complex(1, 7);
        Complex expected = new(-11, 23);

        Complex result = a * b;

        Assert.Equal(expected, result);
    }
}