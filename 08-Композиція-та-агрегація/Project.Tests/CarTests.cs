namespace Project.Tests;

public class CarTests {
    [Fact]
    public void Cant_drive_with_engine_off() {
        Car c = new(1);

        Assert.Throws<InvalidOperationException>(() => c.Drive(10));
    }

    [Fact]
    public void Can_drive_with_engine_on() {
        Car c = new(1);
        c.Start();

        c.Drive(10);
    }

    [Fact]
    public void Cant_drive_negative_amount() {
        Car c = new(1);

        Assert.ThrowsArgumentNegativeException(() => c.Drive(km: -1), "km");
    }

    [Fact]
    public void Cant_create_with_negative_power() {
        Assert.ThrowsArgumentNegativeException(() => new Car(power: -1), "power");
    }
}