namespace Project.Tests;

public class VectorTest {
    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(0, 10, 10, 0, 0)]
    [InlineData(1, 2, 3, 4, 11)]
    public void Dot_returns_correct_value(int lX, int lY, int rX, int rY, int expected) {
        var lhs = new Vector(lX, lY);
        var rhs = new Vector(rX, rY);

        var result = Vector.Dot(lhs, rhs);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 10, 10)]
    [InlineData(3, 4, 5)]
    public void Absolute_returns_correct_value(int x, int y, float expected) {
        var vector = new Vector(x, y);

        var result = vector.Absolute();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Addition_operator_returns_correct_value() {
        var lhs = new Vector(1, 2);
        var rhs = new Vector(3, 4);

        var result = lhs + rhs;

        Assert.Equal(4, result.X);
        Assert.Equal(6, result.Y);
    }
}