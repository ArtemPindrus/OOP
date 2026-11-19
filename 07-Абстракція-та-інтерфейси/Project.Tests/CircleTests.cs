namespace Project.Tests;

public class CircleTests {
    [Fact]
    public void Cant_create_with_negative_radius() {
        Assert.ThrowsArgumentNegativeException(() => new Circle(-1), "radius");
    }
}