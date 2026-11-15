namespace Project;

public class ReverseFormater : Formater {
    public override string Format(string str) => new(str.Reverse().ToArray());
}
