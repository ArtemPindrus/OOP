namespace Project;

public class Car {
    public string Brand { get; }

    /// <summary>
    /// The maximum amount of fuel the car's tank can hold, in liters.
    /// </summary>
    public double TankCapacity { get; }

    /// <summary>
    /// Fuel consumption in liters per 100 kilometers.
    /// </summary>
    public double FuelConsumption { get; }

    /// <summary>
    /// The current amount of fuel in the car's tank, in liters. 
    /// Must be between 0 and TankCapacity.
    /// </summary>
    public double CurrentFuelLevel { 
        get; 
        private set {
            if (value < 0 || value > TankCapacity) {
                throw new ArgumentOutOfRangeException(
                        nameof(value), 
                        $"Current fuel level must be between 0 and {TankCapacity} ({nameof(TankCapacity)})."
                    );
            }

            field = value;
        }
    }

    public Car(string brand, double tankCapacity, double fuelConsumption, double currentFuelLevel) {
        if (tankCapacity <= 0) throw new ArgumentOutOfRangeException(nameof(tankCapacity), "Tank capacity must be greater than zero.");
        if (fuelConsumption <= 0) throw new ArgumentOutOfRangeException(nameof(fuelConsumption), "Fuel consumption must be greater than zero.");
        if (currentFuelLevel < 0 
            || currentFuelLevel > tankCapacity) throw new ArgumentOutOfRangeException(nameof(currentFuelLevel), $"Current fuel level must be between 0 and {tankCapacity} ({nameof(tankCapacity)}).");

        Brand = brand;
        TankCapacity = tankCapacity;
        FuelConsumption = fuelConsumption;
        CurrentFuelLevel = currentFuelLevel;
    }

    /// <summary>
    /// Refuels the car by a specified amount, ensuring that the current fuel level does not exceed the tank capacity.
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Refuel(double amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException(nameof(amount), "Refuel amount cannot be negative.");
        }

        double newFuelLevel = CurrentFuelLevel + amount;
        newFuelLevel = Math.Min(newFuelLevel, TankCapacity);

        CurrentFuelLevel = newFuelLevel;
    }

    /// <summary>
    /// Calculates the maximum distance the car can travel with the current fuel level, based on its fuel consumption rate.
    /// </summary>
    /// <returns></returns>
    public double CalculateMaxDistance() => (CurrentFuelLevel / FuelConsumption) * 100;

    /// <summary>
    /// Drives the car for a specified distance, consuming fuel based on the car's fuel consumption rate.
    /// </summary>
    /// <param name="distance">Distance to travel, in kilometers.</param>
    /// <returns>The actual distance traveled, in kilometers.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="distance"/> is negative.</exception>
    public double Drive(double distance) {
        if (distance < 0) {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance cannot be negative.");
        }

        double maxDistance = CalculateMaxDistance();
        double distanceTraveled = Math.Min(distance, maxDistance);

        double fuelUsed = (FuelConsumption / 100) * distanceTraveled;
        CurrentFuelLevel -= fuelUsed;

        return distanceTraveled;
    }
}
