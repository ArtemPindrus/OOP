namespace Project;

public class Student {
    private readonly List<int> grades;

    public string Surname { get; }
    public IReadOnlyCollection<int> Grades => grades;

    public Student(string surname) {
        Surname = surname;
        grades = new();
    }

    public Student(string surname, IEnumerable<int> grades) {
        Surname = surname;

        if (grades.Any(x => x < 0)) throw new ArgumentException("Grades cannot be negative.", nameof(grades));

        this.grades = new(grades);
    }

    public void AddGrade(int grade) {
        if (grade <= 0) throw new ArgumentException("Grade cannot be negative.", nameof(grade));

        grades.Add(grade);
    }

    public double CalculateAverageGrade() => grades.Average();

    public int GetBestGrade() => grades.Max();

    /// <summary>
    /// Check if the student has any grades below 60, indicating a debt.
    /// </summary>
    public bool HasDebt() => grades.Any(g => g < 60);
}
