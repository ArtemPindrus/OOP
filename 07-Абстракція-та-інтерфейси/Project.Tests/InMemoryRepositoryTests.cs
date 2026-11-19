namespace Project.Tests;

public class InMemoryRepositoryTests {
    [Fact]
    public void Can_get_entity_after_adding_it() {
        Student e = new(1, "Bob");
        InMemoryRepository<Student> sut = new();

        sut.Add(e);

        Student actual = sut.Get(e.Id);
        Assert.Equal(e, actual);
    }

    [Fact]
    public void Cant_add_with_the_same_id() {
        Student e = new(1, "Bob");
        Student e2 = new(1, "Bobby");
        InMemoryRepository<Student> sut = new();

        sut.Add(e);

        Assert.Throws<ArgumentException>(() => sut.Add(e2));
    }

    [Fact]
    public void GetAll_returns_all_entities() {
        Student e = new(1, "Bob");
        Student e2 = new(2, "Bobby");
        Student e3 = new(3, "Bobbess");
        InMemoryRepository<Student> sut = new();

        sut.Add(e);
        sut.Add(e2);
        sut.Add(e3);

        IEnumerable<Student> entities = sut.GetAll();

        Assert.Contains(e, entities);
        Assert.Contains(e2, entities);
        Assert.Contains(e3, entities);
    }
}