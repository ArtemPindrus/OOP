namespace Project;

public class InMemoryRepository<T> : IRepository<T>
    where T : BaseEntity {
    private readonly List<T> items = [];

    public void Add(T entity) {
        if (items.Contains(entity)) throw new ArgumentException($"Entity with Id ({entity.Id} already exists.)");

        items.Add(entity);
    }

    public T Get(int id) => items.First(x => x.Id == id);

    public IEnumerable<T> GetAll() => items;

    public bool Remove(int id) {
        if(items.First(x => x.Id == id) is T item) {
            items.Remove(item);
            return true;
        }

        return false;
    }
}