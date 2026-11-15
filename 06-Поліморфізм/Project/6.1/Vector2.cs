namespace Project;

public record struct Vector2(double X, double Y) {
    public double DistanceTo(Vector2 other) {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
