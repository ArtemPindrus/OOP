namespace Project;

public class Temperature {
    public double Celsius { get; private set; }

    public Temperature(double celsius) {
        Celsius = celsius;
    }

    public static Temperature FromFahrenheit(double fahrenheit) {
        double celsius = (fahrenheit - 32) * 5.0 / 9.0;

        return new Temperature(celsius);
    }

    public static Temperature FromKelvin(double kelvin) {
        double celsius = kelvin - 273.15;

        return new Temperature(celsius);
    }

    public static bool IsValid(double celsius) {
        return celsius >= -273.15;
    }

    public double ToFahrenheit() {
        return Celsius * 9.0 / 5.0 + 32;
    }
}
