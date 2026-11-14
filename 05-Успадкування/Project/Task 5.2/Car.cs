namespace Project;

public class Car : Vehicle {
    public override int Wheels => 4;

    public Car(string brand, int speed) : base(brand, speed) {
    }
}
