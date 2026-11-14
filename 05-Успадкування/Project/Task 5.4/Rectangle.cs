namespace Project;

public class Rectangle : Shape {
    public float Width { get; }
    public float Height { get; }

    public Rectangle(float width, float height) {
        if (width < 0) throw new ArgumentException("Argument can't be negative.", nameof(width));
        if (height < 0) throw new ArgumentException("Argument can't be negative.", nameof(height));

        Width = width;
        Height = height;
    }

    public override float Area() => Width * Height;
}
