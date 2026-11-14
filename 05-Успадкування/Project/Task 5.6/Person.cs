namespace Project;

public class Person {
    public string Surname { get; }
    public int Age { get; }

    public Person(string surname, int age) {
        if (age < 0) throw new ArgumentException("Argument can't be negative.", nameof(age));

        Surname = surname;
        Age = age;
    }
}