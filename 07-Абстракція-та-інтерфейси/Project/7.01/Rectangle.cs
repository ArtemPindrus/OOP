using Project.Exceptions;

namespace Project;

public class Rectangle : Shape {
    public double Length { get; }
    public double Width { get; }

    public Rectangle(double length, double width) {
        ArgumentNegativeException.ThrowIfNegative(length);
        ArgumentNegativeException.ThrowIfNegative(width);

        Length = length;
        Width = width;
    }

    public override double Area() => Length * Width;

    public override double Perimeter() => Length * 2 + Width * 2;
}