using System.Collections;

namespace Library;

public class GenericContainer <T> : IEnumerable
{
    private List<T> items { get; set; }
    public void Add(T item)
    {
        items.Add(item);
    }
    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }
    
}