namespace Project;

public static class EmployeeExtensions {
    public static decimal TotalPayroll(IEnumerable<Employee> employees) =>
        employees.Sum(e => e.Pay());
}