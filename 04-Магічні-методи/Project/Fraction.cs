using Project.Utilities;

namespace Project;

public class Fraction {
    public Fraction(int numerator, int denominator) {
        if (denominator == 0) throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

        int gcd = MathUtils.GetGcd(numerator, denominator);

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public int Numerator { get; }
    public int Denominator { get; }

    public static Fraction operator+(Fraction a, Fraction b) {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b) {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b) {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b) {
        if (b.Numerator == 0) throw new DivideByZeroException("Cannot divide by zero fraction.");

        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new Fraction(numerator, denominator);
    }

    public static bool operator ==(Fraction a, Fraction b) {
        if (ReferenceEquals(a, b)) return true;

        if (a is null || b is null) return false;

        return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
    }

    public static bool operator !=(Fraction a, Fraction b) {
        return !(a == b);
    }

    public override bool Equals(object? obj) => obj is Fraction fraction && this == fraction;

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public static bool operator <(Fraction a, Fraction b) {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator >(Fraction a, Fraction b) {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <=(Fraction a, Fraction b) {
        return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
    }

    public static bool operator >=(Fraction a, Fraction b) {
        return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
    }

    public static implicit operator float(Fraction fraction) {
        return (float)fraction.Numerator / fraction.Denominator;
    }
}