namespace Project;

public class Dog : Animal {
    public Dog(string name) : base(name) {

    }

    protected override string Speak() => "Bark!";
}
