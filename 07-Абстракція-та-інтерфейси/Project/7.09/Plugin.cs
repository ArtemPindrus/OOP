namespace Project;

public abstract class Plugin {
    public abstract string Name { get; }

    public abstract string Run(string data);
}