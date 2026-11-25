using Project.Exceptions;

namespace Project;

public class Mover : Component {
    public int Speed { get; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public Mover(int speed) {
        ArgumentNegativeException.ThrowIfNegative(speed);

        Speed = speed;
    }

    public void Move(int dx, int dy) {
        X += dx * Speed;
        Y += dy * Speed;
    }
}
