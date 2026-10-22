namespace Project;

public class Thermostat {
    public double MinT { get; }
    public double MaxT { get; }

    public double Target {
        get;
        set => field = Math.Clamp(value, MinT, MaxT);
    }

    public Thermostat(double minT, double maxT, double target) {
        if (minT > maxT)
            throw new ArgumentException($"{nameof(minT)} must not be greater than {nameof(maxT)}.");

        MinT = minT;
        MaxT = maxT;
        Target = target;
    }

    /// <summary>
    /// Determine whether heating in a room is required given current temperature.
    /// </summary>
    /// <param name="current">Current temperature.</param>
    public bool HeatingNeeded(double current) => current < Target;
}