namespace Project;

public class Cow : Animal {
    public Cow(string name) : base(name) {

    }

    protected override string Speak() => "Moo";
}