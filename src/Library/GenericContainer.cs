using System.Collections;

namespace Library;

public class GenericContainer <T> : IEnumerable
{
    private List<T> items { get; set; }
    public GenericContainer()
    {
        items = new List<T>();
    }
    public void Add(T item)
    {
        items.Add(item);
    }
    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }

    public int Count()
    {
        return items.Count;
    }
}