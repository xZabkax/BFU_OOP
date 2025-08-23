namespace Lab_5;

public interface IDataRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}