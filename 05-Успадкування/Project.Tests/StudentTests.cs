namespace Project.Tests;

public class StudentTests {
    [Fact]
    public void Cant_create_student_with_negative_group() {
        Assert.Throws<ArgumentException>(() => new Student("Bob", 10, -1));
    }
}
