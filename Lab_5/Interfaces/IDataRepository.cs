namespace Lab_5;

public interface IDataRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Add(params T[] item);
    void Update(T item);
    void Delete(T item);
}