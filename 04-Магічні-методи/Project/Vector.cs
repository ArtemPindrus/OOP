namespace Project;

public class Vector {
    public Vector(float x, float y) {
        X = x;
        Y = y;
    }

    public float X { get; set; }
    public float Y { get; set; }

    public static Vector operator +(Vector lhs, Vector rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y);
    public static Vector operator -(Vector lhs, Vector rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y);
    public static Vector operator -(Vector lhs) => new(-lhs.X, lhs.Y);
    public static Vector operator *(Vector lhs, int rhs) => new(lhs.X * rhs, lhs.Y * rhs);
    public static Vector operator *(int lhs, Vector rhs) => rhs * lhs;

    public static float Dot(Vector lhs, Vector rhs) => lhs.X * rhs.X + lhs.Y * rhs.Y;

    public float Absolute() => MathF.Sqrt(X * X + Y * Y);
}