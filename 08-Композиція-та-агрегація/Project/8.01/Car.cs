using Project.Exceptions;

namespace Project;

public class Car {
    private readonly Engine engine;

    public double Mileage { 
        get; 
        private set {
            ArgumentNegativeException.ThrowIfNegative(value);

            if (value < field) throw new Exception("Mileage cannot reduce.");
            field = value;
        }
    }

    public Car(int power) {
        ArgumentNegativeException.ThrowIfNegative(power);

        engine = new(power);
    }

    public void Drive(double km) {
        ArgumentNegativeException.ThrowIfNegative(km);

        if (engine.State == State.Off) throw new InvalidOperationException("Can't drive with engine off.");

        Mileage += km;
    }

    public void Start() => engine.Start();
    public void Stop() => engine.Stop();
}
