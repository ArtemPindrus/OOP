namespace Project;

public class Complex {
    public float Real { get; }
    public float Imaginary { get; }

    public Complex(float real, float imaginary) {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b) => new(a.Real + b.Real, a.Imaginary + b.Imaginary);
    public static Complex operator +(Complex c, float v) => new(c.Real + v, c.Imaginary + v);
    public static Complex operator +(float v, Complex c) => c + v;

    public static Complex operator -(Complex a, Complex b) => new(a.Real - b.Real, a.Imaginary - b.Imaginary);
    public static Complex operator -(Complex c, float v) => new(c.Real - v, c.Imaginary - v);
    public static Complex operator -(float v, Complex c) => c - v;

    public static Complex operator *(Complex a, Complex b) => new(
        a.Real * b.Real - a.Imaginary * b.Imaginary,
        a.Real * b.Imaginary + a.Imaginary * b.Real
    );

    public static bool operator ==(Complex a, Complex b) => a.Real == b.Real && a.Imaginary == b.Imaginary;
    public static bool operator !=(Complex a, Complex b) => !(a == b);

    public override bool Equals(object? obj) => obj is Complex complex && this == complex;

    public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

    public float AbsoluteValue() => MathF.Sqrt(Real * Real + Imaginary * Imaginary);
    public Complex Conjugate() => new(Real, -Imaginary);
}