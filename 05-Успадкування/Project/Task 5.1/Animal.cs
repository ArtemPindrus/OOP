namespace Project;

public abstract class Animal {
    public string Name { get; }

    public Animal(string name) {
        Name = name;
    }

    public string Intro() => $"{Name} says: {Speak()}";

    protected abstract string Speak();
}