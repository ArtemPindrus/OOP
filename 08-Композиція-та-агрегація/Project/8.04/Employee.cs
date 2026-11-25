namespace Project;

public class Employee {
    private readonly List<Team> teams = [];

    public IEnumerable<Team> Teams => teams;

    public decimal Salary { get; }

    public Employee(decimal salary) {
        Salary = salary;
    }

    public void AddTeam(Team t) {
        if (!teams.Contains(t)) teams.Add(t);
        if (!t.Members.Contains(this)) t.AddMember(this);
    }

    public void RemoveTeam(Team t) {
        teams.Remove(t);
        if (t.Members.Contains(this)) t.RemoveMember(this);
    }
}