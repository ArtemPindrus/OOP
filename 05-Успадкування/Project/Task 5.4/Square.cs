namespace Project;

public class Square : Rectangle {
    public Square(float length) : base(length, length) {
        if (length < 0) throw new ArgumentException("Argument can't be negative.", nameof(length));
    }
}