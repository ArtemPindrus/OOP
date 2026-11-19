namespace Project;

public interface IRepository<T> 
    where T : BaseEntity {
    void Add(T entity);
    T Get(int id);
    IEnumerable<T> GetAll();

    /// <summary>
    /// Remove the entity by id.
    /// </summary>
    /// <returns>true if entity was in repository and was deleted. false if there was not entity matching id.</returns>
    bool Remove(int id);
}