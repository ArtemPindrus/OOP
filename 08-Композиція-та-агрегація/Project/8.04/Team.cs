namespace Project;

public class Team {
    private readonly List<Employee> members = [];

    public IEnumerable<Employee> Members => members;

    public void AddMember(Employee employee) {
        if (!members.Contains(employee)) members.Add(employee);
        if (!employee.Teams.Contains(this)) employee.AddTeam(this);
    }

    public void RemoveMember(Employee employee) {
        members.Remove(employee);
        if (employee.Teams.Contains(this)) employee.RemoveTeam(this);
    }

    public decimal TotalSalary() => members.Sum(x => x.Salary);
}