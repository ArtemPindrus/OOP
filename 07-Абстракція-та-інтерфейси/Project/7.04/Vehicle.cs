using Project.Exceptions;

namespace Project;

public abstract class Vehicle {
    // Maximum speed in km/h.
    public abstract double MaxSpeed { get; }

    /// <summary>
    /// Calculate travel time in hours for a distance in km.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNegativeException">km are negative.</exception>
    public double TravelTime(double km) {
        ArgumentNegativeException.ThrowIfNegative(km);

        return km / MaxSpeed;
    }
}