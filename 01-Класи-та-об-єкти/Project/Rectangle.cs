namespace Project;

public class Rectangle {
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height) {
        if (width < 0) throw new ArgumentException("Width cannot be negative.", nameof(width));
        if (height < 0) throw new ArgumentException("Height cannot be negative.", nameof(height));

        Width = width;
        Height = height;
    }

    public double CalculateArea() => Width * Height;

    public double CalculatePerimeter() => 2 * (Width + Height);

    public bool IsSquare() => Width == Height;
}
