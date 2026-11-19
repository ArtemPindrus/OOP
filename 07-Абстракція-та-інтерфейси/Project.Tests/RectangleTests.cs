namespace Project.Tests; 

public class RectangleTests {
    [Fact]
    public void Cant_create_with_negative_length() {
        Assert.ThrowsArgumentNegativeException(() => new Rectangle(length: -1, width: 10), "length");
    }

    [Fact]
    public void Cant_create_with_negative_width() {
        Assert.ThrowsArgumentNegativeException(() => new Rectangle(length: 10, width: -1), "width");
    }
}
