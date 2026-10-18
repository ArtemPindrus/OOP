namespace Project;

public static class MathUtils {
    public static int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return Math.Abs(a);
    }

    public static bool IsPrime(int n) {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0) return false;
        }
        return true;
    }

    public static int Factorial(int n) {
        if (n == 0) return 1;

        return n * Factorial(n - 1);
    }

    public static int Fibonacci(int n) {
        if (n <= 1) return n;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}