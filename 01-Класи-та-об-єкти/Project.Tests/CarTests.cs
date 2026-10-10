namespace Project.Tests {
    public class CarTests {
        [Test]
        public void Constructor_TankCapacityNegativeOrZero_ThrowsArgumentOutOfRangeException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Car("TestBrand", 0, 5, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Car("TestBrand", -1, 5, 10));
        }

        [Test]
        public void Constructor_FuelConsumptionNegativeOrZero_ThrowsArgumentOutOfRangeException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Car("TestBrand", 100, 0, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Car("TestBrand", 100, -1, 10));
        }

        [TestCase(100, 101)]
        [TestCase(100, -1)]
        public void Constructor_CurrentFuelLevelOutOfRange_ThrowsArgumentOutOfRangeException(double capacity, double fuelLevel) {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Car("TestBrand", capacity, 5, fuelLevel));
        }

        [Test]
        public void Refuel_AmountNegative_ThrowsArgumentOutOfRangeException() {
            var car = new Car("TestBrand", 100, 5, 50);
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Refuel(-10));
        }

        [TestCase(100, 50, 30, 80)]
        [TestCase(80, 50, 50, 80)]
        [TestCase(30, 30, 50, 30)]
        public void Refuel_CheckCurrentFuelLevelAfter(int capacity, int currentLevel, int refuelAmount, int expectedLevel) {
            var car = new Car("TestBrand", capacity, fuelConsumption: 5, currentLevel);
            car.Refuel(refuelAmount);

            Assert.That(car.CurrentFuelLevel, Is.EqualTo(expectedLevel));
        }

        [Test]
        public void Drive_DistanceNegative_ThrowsArgumentOutOfRangeException() {
            var car = new Car("TestBrand", 100, 5, 50);

            Assert.Throws<ArgumentOutOfRangeException>(() => car.Drive(-10));
        }
    }
}