namespace Project;

public abstract class Vehicle {
    public string Brand { get; }
    public int Speed { get; }
    public abstract int Wheels { get; }

    public Vehicle(string brand, int speed) {
        if (speed < 0) throw new ArgumentException("Speed can't be negative.", nameof(speed));

        Brand = brand;
        Speed = speed;
    }
}