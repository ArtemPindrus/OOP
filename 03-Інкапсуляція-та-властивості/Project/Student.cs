namespace Project;

public class Student {
    private readonly List<int> grades = [];

    public Student(int id, string name) {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
    public int[] Grades => grades.ToArray();

    public Student AddGrade(int grade) {
        grades.Add(grade);

        return this;
    }
}