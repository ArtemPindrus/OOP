namespace Project;

public class Employee {
    public string Name { get; }
    public decimal Rate { get; }

    public Employee(string name, decimal rate) {
        if (rate < 0) throw new ArgumentException("Rate can't be negative.", nameof(rate));

        Name = name;
        Rate = rate;
    }

    public virtual decimal Pay() => Rate;
}