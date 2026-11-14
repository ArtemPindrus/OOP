namespace Project.Tests;

public class TeacherTests {
    [Fact]
    public void Cant_create_teacher_with_negative_group() {
        Assert.Throws<ArgumentException>(() => new Teacher("Bob", 45, -10));
    }
}