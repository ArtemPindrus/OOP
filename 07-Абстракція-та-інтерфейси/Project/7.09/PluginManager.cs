namespace Project;

public class PluginManager {
    private readonly List<Plugin> plugins = [];

    public IReadOnlyList<Plugin> Plugins => plugins;

    public void Register<T>() where T: Plugin {
        plugins.Add(Activator.CreateInstance<T>());
    }

    public string RunAll(string data) {
        foreach (var plugin in plugins)
            data = plugin.Run(data);
        return data;
    }
}
