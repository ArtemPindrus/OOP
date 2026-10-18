namespace Project;

public class Employee { 
    public static int Count { get; private set; }

    public string Name { get; }

    public int Salary {
        get;
        private set {
            if (value < 0) throw new ArgumentException("Salary cannot be negative", nameof(Salary));
            
            field = value;
        }
    }

    public Employee(string name, int salary = 10000) {
        if (salary < 0) throw new ArgumentException("Salary cannot be negative", nameof(salary));

        Name = name;
        Salary = salary;

        Count++;
    }

    /// <summary>
    /// Raises the salary of the employee by a given percentage.
    /// </summary>
    /// <param name="percents">The percentage by which to raise the salary. Greater than or equal to zero.</param>
    /// <exception cref="ArgumentException"><paramref name="percents"/> is negative.</exception>
    public void RaiseSalary(float percents) {
        if (percents < 0) throw new ArgumentException("Raise percentage cannot be negative", nameof(percents));

        float normalizedPercentage = 1 + percents / 100;
        Salary = (int)(Salary * normalizedPercentage);
    }
}
