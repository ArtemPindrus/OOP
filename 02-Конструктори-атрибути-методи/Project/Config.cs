namespace Project;

public class Config {
    private static readonly Dictionary<string, string> defaults = new();

    private readonly Dictionary<string, string> settings = new();

    /// <summary>
    /// Sets a default value for a configuration key.
    /// </summary>
    public static void SetDefault(string key, string value) {
        defaults[key] = value;
    }

    /// <summary>
    /// Sets a value for a configuration key.
    /// </summary>
    public void Set(string key, string value) {
        settings[key] = value;
    }

    /// <summary>
    /// Gets the value for a configuration key. If the key is not set, it returns the default value.
    /// </summary>
    public string Get(string key) {
        if (settings.TryGetValue(key, out string? value)) {
            return value;
        }

        return defaults[key];
    }
}