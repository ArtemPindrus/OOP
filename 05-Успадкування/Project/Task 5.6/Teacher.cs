namespace Project;

public class Teacher : Person {
    public int Department { get; }

    public Teacher(string surname, int age, int department) : base(surname, age) {
        if (department < 0) throw new ArgumentException("Argument can't be negative.", nameof(department));

        Department = department;
    }
}
