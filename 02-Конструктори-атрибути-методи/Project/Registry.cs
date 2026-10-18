namespace Project;

public class Registry { 
    private static readonly List<Registry> instances = [];

    public string Name { get; }

    public Registry(string key) {
        Name = key;

        instances.Add(this);
    }

    public static IEnumerable<Registry> All() => instances;

    public static Registry? Find(string name) {
        return instances.FirstOrDefault(i => i.Name == name);
    }

    public static void Clear() {
        instances.Clear();
    }
}