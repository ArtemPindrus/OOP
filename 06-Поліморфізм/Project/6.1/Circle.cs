using Project.Exceptions;

namespace Project;

public class Circle : Shape {
    public double Radius { get; }

    public Circle(double radius) {
        ArgumentNegativeException.ThrowIfNegative(radius);

        Radius = radius;
    }

    public override double Area() => Radius * Radius * Math.PI;

    public override double Perimeter() => 2 * Math.PI * Radius;
}
