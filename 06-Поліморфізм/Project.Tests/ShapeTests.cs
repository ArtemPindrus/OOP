namespace Project.Tests; 

public class ShapeTests {
    [Fact]
    public void Circle_area_is_correct() {
        double expected = 10;
        double radius = Math.Sqrt(expected/Math.PI);
        Circle sut = new(radius);

        double actual = sut.Area();

        Assert.Equal(expected, actual, 0.01);
    }

    [Fact]
    public void TotalArea_is_calculated_correctly() {
        double radius = Math.Sqrt(10 / Math.PI);
        Circle c = new(radius); // a: 10
        Triangle t1 = new( // a: 10
            new Vector2(0, 0),
            new Vector2(5, 0),
            new Vector2(2.5f, 4)
        );
        Triangle t2 = new( // a: 15
            new Vector2(0, 0),
            new Vector2(6, 0),
            new Vector2(3, 5)
        );
        double expected = 35;
        Shape[] sut = [c, t1, t2];

        double actual = sut.TotalArea();

        Assert.Equal(expected, actual, 0.01);
    }

    [Fact]
    public void Largest_returns_correct_shape() {
        double radius = Math.Sqrt(10 / Math.PI);
        Circle c = new(radius); // a: 10
        Triangle t1 = new( // a: 10
            new Vector2(0, 0),
            new Vector2(5, 0),
            new Vector2(2.5f, 4)
        );
        Triangle t2 = new( // a: 15
            new Vector2(0, 0),
            new Vector2(6, 0),
            new Vector2(3, 5)
        );

        Shape[] sut = [c, t1, t2];

        Shape actual = sut.Largest();

        Assert.Equal(t2, actual);
    }
}