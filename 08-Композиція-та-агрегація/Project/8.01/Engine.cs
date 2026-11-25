using Project.Exceptions;

namespace Project;

public class Engine {
    public int Power { get; }
    public State State { get; private set; } = State.Off;

    public Engine(int power) {
        ArgumentNegativeException.ThrowIfNegative(power);

        Power = power;
    }

    public void Start() {
        if (State == State.On) return;

        State = State.On;
    }

    public void Stop() {
        if (State == State.Off) return;

        State = State.Off;
    }
}
