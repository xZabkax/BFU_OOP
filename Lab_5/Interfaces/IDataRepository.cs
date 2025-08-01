namespace Lab_5;

public interface IDataRepository
{
    /*- get_all(self) -> Sequence[T]
    - get_by_id(self, id: int) -> T | None
    - add(self, item: T) -> None
    - update(self, item: T) -> None
    - delete(self, item: T) -> None*/

    List<Object> GetAll();
    Object? GetById(int id);
    void Add(Object T);
    void Update(Object T);
    void Delete(Object T);
}