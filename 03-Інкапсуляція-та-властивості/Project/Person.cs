namespace Project;

public class Person {
    public Person(string name, int age) {
        Name = name;
        Age = age;
    }

    public string Name {
        get;
        set {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name should be non-empty.");

            field = value.Trim();
        }
    }

    public int Age {
        get;
        set {
            if (value < 0 || value > 150) throw new ArgumentOutOfRangeException("Age should be in [0; 150] range.");

            field = value;
        }
    }

    public bool IsAdult => Age >= 18;
}