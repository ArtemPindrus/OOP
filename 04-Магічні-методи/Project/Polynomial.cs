using System.Globalization;
using System.Text;

namespace Project;

public class Polynomial {
    private readonly double[] coefficients;

    public Polynomial(params double[] coeffs) {
        if (coeffs == null || coeffs.Length == 0) {
            this.coefficients = new[] { 0.0 };
            return;
        }

        // Trim trailing zeros (highest-order terms), keeping at least a0.
        int last = coeffs.Length - 1;
        while (last > 0 && coeffs[last] == 0) last--;

        this.coefficients = new double[last + 1];
        Array.Copy(coeffs, this.coefficients, last + 1);
    }

    public int Degree => coefficients.Length - 1;

    public double this[int i] =>
        i < 0 ? throw new ArgumentOutOfRangeException(nameof(i))
              : i < coefficients.Length ? coefficients[i] : 0.0;

    public double Evaluate(double x) {
        double result = 0;
        for (int i = coefficients.Length - 1; i >= 0; i--)
            result = result * x + coefficients[i];
        return result;
    }

    public static Polynomial operator +(Polynomial a, Polynomial b) {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));

        int n = Math.Max(a.coefficients.Length, b.coefficients.Length);
        var result = new double[n];
        for (int i = 0; i < n; i++)
            result[i] = a[i] + b[i];
        return new Polynomial(result);
    }

    public static Polynomial operator *(Polynomial a, Polynomial b) {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));

        var result = new double[a.coefficients.Length + b.coefficients.Length - 1];
        for (int i = 0; i < a.coefficients.Length; i++)
            for (int j = 0; j < b.coefficients.Length; j++)
                result[i + j] += a.coefficients[i] * b.coefficients[j];
        return new Polynomial(result);
    }

    public static bool operator ==(Polynomial a, Polynomial b) {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        if (a.coefficients.Length != b.coefficients.Length) return false;
        for (int i = 0; i < a.coefficients.Length; i++)
            if (a.coefficients[i] != b.coefficients[i]) return false;

        return true;
    }

    public static bool operator !=(Polynomial a, Polynomial b) => !(a == b);

    public override string ToString() {
        var sb = new StringBuilder();

        for (int i = 0; i < coefficients.Length; i++) {
            double c = coefficients[i];
            if (c == 0) continue;

            bool first = sb.Length == 0;
            double abs = Math.Abs(c);

            if (first) {
                if (c < 0) sb.Append('-');
            } else {
                sb.Append(c < 0 ? " - " : " + ");
            }

            // Omit a coefficient of 1 on non-constant terms ("x" instead of "1x").
            if (i == 0 || abs != 1)
                sb.Append(abs.ToString(CultureInfo.InvariantCulture));

            if (i >= 1) sb.Append('x');
            if (i >= 2) sb.Append('^').Append(i);
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
