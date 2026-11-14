namespace Project.Tests;

public class VehicleTests {
    [Fact]
    public void Cant_create_vehicle_with_negative_speed() {
        Assert.Throws<ArgumentException>(() => new Car("Toyota", -10));
        Assert.Throws<ArgumentException>(() => new Bike("Yamaha", -5));
        Assert.Throws<ArgumentException>(() => new Truck("Ford", -20, 1000));
    }

    [Fact]
    public void Cant_create_truck_with_negative_load_capacity() {
        Assert.Throws<ArgumentException>(() => new Truck("Ford", 20, -1000));
    }
    
    [Fact]
    public void Truck_has_six_wheels() {
        var truck = new Truck("Ford", 20, 1000);
        Assert.Equal(6, truck.Wheels);
    }
}