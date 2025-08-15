namespace Lab_5;

public interface IDataRepository<T>
{
    /*- get_all(self) -> Sequence[T]
    - get_by_id(self, id: int) -> T | None
    - add(self, item: T) -> None
    - update(self, item: T) -> None
    - delete(self, item: T) -> None*/

    List<T> GetAll();
    T? GetById(int id);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}