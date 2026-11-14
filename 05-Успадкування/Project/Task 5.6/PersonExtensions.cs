namespace Project;

public static class PersonExtensions {
    extension(IEnumerable<Person> list) {
        public IEnumerable<Student> GetStudents() => list.OfType<Student>();
    }
}