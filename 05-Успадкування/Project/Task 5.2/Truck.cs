namespace Project;

public class Truck : Vehicle {
    public override int Wheels => 6;

    public int LoadCapacity { get; }

    public Truck(string brand, int speed, int loadCapacity) : base(brand, speed) {
        if (loadCapacity < 0) throw new ArgumentException("Argument can't be negative.", nameof(loadCapacity));

        LoadCapacity = loadCapacity;
    }
}