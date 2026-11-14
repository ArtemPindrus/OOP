namespace Project;

public class Bike : Vehicle {
    public override int Wheels => 2;

    public Bike(string brand, int speed) : base(brand, speed) {
    }
}
