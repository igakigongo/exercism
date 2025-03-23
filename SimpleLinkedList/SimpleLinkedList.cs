using System.Collections;

namespace SimpleLinkedList;

public class SimpleLinkedList<T>() : IEnumerable<T>
{
    private T[] _list = new T[4];
    private int _currentIndex = -1;

    public SimpleLinkedList(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
            Push(item);
    }

    public int Count => _currentIndex + 1;

    public void Push(T value)
    {
        if (_currentIndex == _list.Length - 1)
            Grow();
        
        _list[++_currentIndex] = value;
    }

    public T Pop()
    {
        var element = _list[_currentIndex];
        _list[_currentIndex--] = default!;
        return element;
    }

    private void Grow()
    {
        var array = new T[_list.Length * 2];
        Array.Copy(_list, array, _list.Length);
        _list = array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(var i = _currentIndex; i >= 0; i--)
            yield return _list[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}