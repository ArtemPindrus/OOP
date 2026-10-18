namespace Project.Tests;

public class EmployeeTests {
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(5)]
    [TestCase(10)]
    public void Count_ReturnsCorrectValue(int instances) {
        typeof(Employee)?.GetProperty(nameof(Employee.Count))?.SetValue(null, 0);

        for (int i = 0; i < instances; i++) {
            Employee e = new("test");
        }

        Assert.That(Employee.Count, Is.EqualTo(instances));
    }

    [TestCase(10000, 0, 10000)]
    [TestCase(10000, 10, 11000)]
    [TestCase(10000, 50, 15000)]
    public void RaiseSalary_ModifiesSalaryCorrectly(int salary, int percentage, int expected) {
        Employee e = new("test", salary);
        e.RaiseSalary(percentage);

        Assert.That(e.Salary, Is.EqualTo(expected));
    }
}