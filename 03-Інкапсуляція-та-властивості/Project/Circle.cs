namespace Project;

public class Circle {
    /// <summary>
    /// Get the amount of times <see cref="Area"/> has been calculated.
    /// </summary>
    public int ComputeCount { get; private set; }

    /// <summary>
    /// Get or set radius. Triggers <see cref="Area"/> recalculation.
    /// </summary>
    public double Radius { 
        get; 
        set {
            field = value;
            RecalculateArea();
        }
    }

    /// <summary>
    /// Get area of this circle.
    /// </summary>
    public double Area { get; private set; }

    public Circle(double radius) {
        Radius = radius;
    }

    private void RecalculateArea() {
        Area = 2 * Math.PI * Radius;
        ComputeCount++;
    }
}