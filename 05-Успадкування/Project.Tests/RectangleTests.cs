namespace Project.Tests;

public class RectangleTests {
    [Fact]
    public void Cant_construct_rectangle_with_negative_width() {
        Assert.Throws<ArgumentException>(() => new Rectangle(-1, 1));
    }

    [Fact]
    public void Cant_construct_rectangle_with_negative_height() {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, -1));
    }

    [Theory]
    [InlineData(10,10,100)]
    [InlineData(0,10,0)]
    [InlineData(1,10,10)]
    public void Area_is_calculated_correctly(float width, float height, float expected) {
        Rectangle sut = new(width, height);

        float actual = sut.Area();

        Assert.Equal(expected, actual);
    }
}