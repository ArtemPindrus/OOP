namespace Project;

public class Entity {
    private readonly Dictionary<Type, Component> components = [];

    public string Name { get; }

    public Entity(string name) {
        Name = name;
    }

    public Entity Add<T>(T component) where T : Component {
        ArgumentNullException.ThrowIfNull(component);

        if (!components.TryAdd(typeof(T), component))
            throw new InvalidOperationException($"{Name} already has a {typeof(T).Name}.");

        return this;
    }

    public bool TryGet<T>(out T component) where T : Component {
        if (components.TryGetValue(typeof(T), out var c)) {
            component = (T)c;
            return true;
        }
        component = null!;
        return false;
    }

    public T Get<T>() where T : Component =>
        TryGet<T>(out var c) ? c : throw new InvalidOperationException($"{Name} has no {typeof(T).Name}.");
}
