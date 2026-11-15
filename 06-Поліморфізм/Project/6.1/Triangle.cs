namespace Project;

public class Triangle : Shape {
    public Vector2 A { get; }
    public Vector2 B { get; }
    public Vector2 C { get; }

    public Triangle(Vector2 a, Vector2 b, Vector2 c) {
        A = a;
        B = b;
        C = c;
    }

    public override double Area() {
        double area = Math.Abs(
            (B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y)
        ) / 2;
        return area;
    }

    public override double Perimeter() {
        double sideAB = A.DistanceTo(B);
        double sideBC = B.DistanceTo(C);
        double sideCA = C.DistanceTo(A);

        return sideAB + sideBC + sideCA;
    }
}
