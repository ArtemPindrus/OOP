using NUnit.Framework;

namespace Project.Tests {
    [TestFixture]
    public class StudentTests {
        private Student _student;

        [SetUp]
        public void SetUp() {
            _student = new Student(1, "John Doe");
        }

        [Test]
        public void Constructor_SetsIdCorrectly() {
            Assert.That(_student.Id, Is.EqualTo(1));
        }

        [Test]
        public void Constructor_SetsNameCorrectly() {
            Assert.That(_student.Name, Is.EqualTo("John Doe"));
        }

        [Test]
        public void Grades_InitiallyEmpty() {
            Assert.That(_student.Grades, Is.Empty);
        }

        [Test]
        public void AddGrade_AddsGradeSuccessfully() {
            _student.AddGrade(85);

            Assert.That(_student.Grades, Has.Length.EqualTo(1));
            Assert.That(_student.Grades[0], Is.EqualTo(85));
        }

        [Test]
        public void AddGrade_ReturnsThisForFluentInterface() {
            var result = _student.AddGrade(85);

            Assert.That(result, Is.SameAs(_student));
        }

        [Test]
        public void AddGrade_SupportsMethodChaining() {
            _student.AddGrade(85).AddGrade(90).AddGrade(95);

            Assert.That(_student.Grades, Has.Length.EqualTo(3));
            Assert.That(_student.Grades, Is.EqualTo(new[] { 85, 90, 95 }));
        }

        [Test]
        public void Grades_ReturnsArrayCopyNotInternalList() {
            _student.AddGrade(85);
            var grades1 = _student.Grades;

            _student.AddGrade(90);
            var grades2 = _student.Grades;

            Assert.That(grades1, Has.Length.EqualTo(1));
            Assert.That(grades2, Has.Length.EqualTo(2));
        }

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        public void AddGrade_AcceptsDifferentGradeValues(int grade) {
            _student.AddGrade(grade);

            Assert.That(_student.Grades, Does.Contain(grade));
        }

        [Test]
        public void AddGrade_MultipleStudentsIndependent() {
            var student1 = new Student(1, "Alice");
            var student2 = new Student(2, "Bob");

            student1.AddGrade(85);
            student2.AddGrade(90);

            Assert.That(student1.Grades, Has.Length.EqualTo(1));
            Assert.That(student1.Grades[0], Is.EqualTo(85));
            Assert.That(student2.Grades, Has.Length.EqualTo(1));
            Assert.That(student2.Grades[0], Is.EqualTo(90));
        }
    }
}