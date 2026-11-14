namespace Project;

public class Student : Person {
    public int Group { get; }

    public Student(string surname, int age, int group) : base(surname, age) {
        if (group < 0) throw new ArgumentException("Argument can't be negative.", nameof(group));

        Group = group;
    }
}
