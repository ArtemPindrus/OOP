namespace Project;

public record class Student(int Id, string Name) : BaseEntity(Id) {
    public virtual bool Equals(Student? other) => other is not null
        && other.Id == Id;

    public override int GetHashCode() => Id.GetHashCode();
}