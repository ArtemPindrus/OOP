namespace Project;

public class Temperature {
    public double Celsius {
        get;
        set {
            if (value < -273.15) throw new ArgumentException("Celsius cannot be lower than -273.15");

            field = value;
        }
    }

    public double Fahrenheit {
        get => (Celsius * 1.8) + 32;
        set => Celsius = (value - 32) * 5 / 9;
    }

    public Temperature(double celsius) {
        Celsius = celsius;
    }
}