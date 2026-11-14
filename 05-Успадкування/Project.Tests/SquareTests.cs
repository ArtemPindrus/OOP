namespace Project.Tests;

public class SquareTests {
    [Fact]
    public void Cant_construct_square_with_negative_length() {
        Assert.Throws<ArgumentException>(() => new Square(-1));
    }

    [Theory]
    [InlineData(10, 100)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void Area_is_calculated_correctly(float length, float expected) {
        Square sut = new(length);

        float actual = sut.Area();

        Assert.Equal(expected, actual);
    }
}