using System.Collections;

namespace SimpleLinkedList;

public class SimpleLinkedList<T>() : IEnumerable<T>
{
    private readonly List<T> _list = [];

    public SimpleLinkedList(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
            Push(item);
    }

    public int Count => _list.Count;

    public void Push(T value) => _list.Add(value);

    public T Pop()
    {
        var value = _list.LastOrDefault() ?? default(T);
        _list.RemoveAt(_list.Count - 1);
        return value!;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = _list.Count - 1; i >= 0; i--)
            yield return _list[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}