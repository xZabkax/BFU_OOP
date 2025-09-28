using System.Reflection;
using System.Text.Json;

namespace Lab_5;

public abstract class DataRepository<T> : IDataRepository<T> where T : class
{
    protected readonly string _filePath;
    protected List<T> _items = new ();
    
    protected DataRepository(string filePath)
    {
        _filePath = filePath;
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Файла с данными не существует.");
            return;
        }
        try
        {
            var json = File.ReadAllText(_filePath);
            _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void SaveData()
    {
        try
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _items.AsReadOnly();
    }

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(item => (int)item.GetType().GetProperty("Id")!.GetValue(item)! == id);
    }

    public void Add(params T[] items)
    {
        foreach (var item in items)
        {
            _items.Add(item);
        }
        SaveData();
    }

    public void Update(T item)
    {
        var id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
        var itemInList = GetById(id);
        
        if (itemInList is null) return;

        _items[_items.IndexOf(itemInList)] = item;
        SaveData();
    }

    public void Delete(T item)
    {
        var id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
        var itemInList = GetById(id);

        if (itemInList is null) return;
        
        _items.Remove(itemInList);
        SaveData();
    }
}