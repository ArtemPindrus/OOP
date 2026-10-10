namespace Project.Tests {
    public class StudentTests {
        public void Constructor_NegativeGrade_ThrowsArgumentException() {
            List<int> grades = new() { 90, -10, 80 };

            Assert.Throws<ArgumentException>(() => new Student("Doe", grades));
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void AddGrade_NegativeGrade_ThrowsArgumentException(int grade) {
            Student student = new("Doe");

            Assert.Throws<ArgumentException>(() => student.AddGrade(grade));
        }

        public void HasDebt_GradesBelow60_ReturnsTrue() {
            List<int> grades = new() { 90, 50, 80 };
            Student student = new("Doe", grades);

            Assert.That(student.HasDebt());
        }

        public void HasDebt_AllGradesAbove60_ReturnsFalse() {
            List<int> grades = new() { 90, 70, 80 };
            Student student = new("Doe", grades);

            Assert.That(!student.HasDebt());
        }
    }
}