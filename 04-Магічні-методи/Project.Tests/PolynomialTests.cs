namespace Project.Tests;

public class PolynomialTests {
    [Fact]
    public void Equality_returns_true_for_same_coefficients() {
        var p1 = new Polynomial(1, 2, 3);
        var p2 = new Polynomial(1, 2, 3);
        Assert.True(p1 == p2);
        Assert.False(p1 != p2);
    }

    [Fact]
    public void Addition_works_for_polynomials_of_different_degrees() {
        var p1 = new Polynomial(1, 2);
        var p2 = new Polynomial(3, 4, 5);

        var sum = p1 + p2;

        Assert.Equal(4, sum[0]);
        Assert.Equal(6, sum[1]);
        Assert.Equal(5, sum[2]);
    }

    [Theory]
    [InlineData(new double[] { 1, 0, 2 }, "1 + 2x^2")]
    [InlineData(new double[] { 3, -1 }, "3 - x")]
    [InlineData(new double[] { 0, -1, 10 }, "-x + 10x^2")]
    public void ToString_formats_correctly(double[] coeffs, string expected) {
        var p = new Polynomial(coeffs);

        string actual = p.ToString();

        Assert.Equal(expected, actual);
    }
}