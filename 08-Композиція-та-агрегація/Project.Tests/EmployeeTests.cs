namespace Project.Tests;

public class EmployeeTests {
    [Fact]
    public void Maintains_both_sides_of_relationship() {
        var employee = new Employee(5000);
        var employee2 = new Employee(10000);
        var team = new Team();
        var team2 = new Team();

        team.AddMember(employee);
        team.AddMember(employee2);
        employee.RemoveTeam(team);
        team2.AddMember(employee2);
        employee2.RemoveTeam(team2);
        employee.AddTeam(team);
        team2.AddMember(employee2);

        // team:  e1, e2
        Assert.Equal(2, team.Members.Count());
        Assert.Contains(employee, team.Members);
        Assert.Contains(employee2, team.Members);

        // team2: e2
        Assert.Single(team2.Members);
        Assert.Contains(employee2, team2.Members);

        // e1
        Assert.Single(employee.Teams);
        Assert.Contains(team, employee.Teams);

        // e2
        Assert.Equal(2, employee2.Teams.Count());
        Assert.Contains(team, employee2.Teams);
        Assert.Contains(team2, employee2.Teams);
    }
}