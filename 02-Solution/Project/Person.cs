namespace Project;

public class Person {
    public string FirstName { get; }
    public string LastName { get; }

    public Person(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Person FromFullName(string fullName) {
        var parts = fullName.Split(' ');
        if (parts.Length != 2) {
            throw new ArgumentException("Full name must be in format: 'FirstName LastName'.");
        }

        return new Person(parts[0], parts[1]);
    }

    public string FullName() => $"{FirstName} {LastName}";

    public string Initials() => $"{FirstName[0]}. {LastName[0]}.";
}