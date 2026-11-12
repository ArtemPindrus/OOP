namespace Project.Tests;

public class FractionTests {
    [Theory]
    [InlineData(2, 4, 1, 2)]
    [InlineData(3, 6, 1, 2)]
    [InlineData(16, 24, 2, 3)]
    public void Constructor_reduces_fraction(int numerator, int denominator, int expectedNum, int expectedDenom) {
        var fraction = new Fraction(numerator, denominator);

        Assert.Equal(expectedNum, fraction.Numerator);
        Assert.Equal(expectedDenom, fraction.Denominator);
    }

    [Fact]
    public void Comparisons_works_correctly() {
        var fraction1 = new Fraction(1, 2);
        var fraction2 = new Fraction(2, 4);
        var fraction3 = new Fraction(3, 4);

        Assert.True(fraction1 == fraction2);
        Assert.False(fraction1 != fraction2);
        Assert.True(fraction1 < fraction3);
        Assert.False(fraction3 < fraction1);
    }

    [Fact]
    public void Addition_works_correctly() {
        var fraction1 = new Fraction(1, 2);
        var fraction2 = new Fraction(1, 3);
        Fraction expected = new(5, 6);

        var result = fraction1 + fraction2;

        Assert.Equal(expected, result);
    }
}