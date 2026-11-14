namespace Project.Tests;

public class EmployeeTests {
    [Fact]
    public void Cant_create_employee_with_negative_rate() {
        Assert.Throws<ArgumentException>(() => new Employee("John Doe", -100m));
        Assert.Throws<ArgumentException>(() => new Manager("John Doe", -100m, 0));
    }

    [Fact]
    public void Cant_create_developer_with_negative_level() {
        Assert.Throws<ArgumentException>(() => new Developer("John Doe", 100m, -1));
    }

    [Fact]
    public void Cant_create_manager_with_negative_bonus() {
        Assert.Throws<ArgumentException>(() => new Manager("John Doe", 100m, -100m));
    }

    [Fact]
    public void TotalPayroll_returns_correct_value() {
        List<Employee> e = [
            new Employee("John Doe", 100m), // 100
            new Developer("Jane Doe", 200m, 1), // 200 + 200 = 400
            new Manager("Jim Doe", 300m, 50m) // 300 + 50 = 350
        ];
        decimal expected = 850m;

        decimal totalPayroll = e.Sum(emp => emp.Pay());

        Assert.Equal(expected, totalPayroll);
    }
}