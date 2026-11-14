namespace Project;

public class Cat : Animal {
    public Cat(string name) : base(name) {

    }

    protected override string Speak() => "Meow";
}
