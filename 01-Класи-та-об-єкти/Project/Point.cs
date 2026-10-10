namespace Project; 

/// <summary>
/// A class that represents a point in 2D space.
/// </summary>
public class Point {
    public int X { get; private set; }
    public int Y { get; private set; }

    /// <summary>
    /// Creates a new point with the specified coordinates.
    /// </summary>
    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Calculates the distance from this point to another point.
    /// </summary>
    /// <param name="other">The other point.</param>
    /// <returns>The distance between the two points.</returns>
    public double DistanceTo(Point other) {
        int dx = X - other.X;
        int dy = Y - other.Y;

        return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// Displaces the point by the specified amounts in the x and y directions.
    /// </summary>
    public void Move(int dx, int dy) {
        X += dx;
        Y += dy;
    }

    /// <summary>
    /// Determines whether the point is at the origin (0, 0).
    /// </summary>
    public bool IsOrigin() => X == 0 && Y == 0;
}
