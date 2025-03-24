namespace LinkedList;

public class Node<T>
{
    public required T Data { get; set; }
    public Node<T>? Previous { get; set; }
    public Node<T>? Next { get; set; }
}

public class Deque<T>
{
    private Node<T>? _head;

    public void Push(T value)
    {
        if (_head == null)
            _head = new Node<T> { Data = value };
        else
        {
            var current = _head;
            while (current.Next != null)
                current = current.Next;

            current.Next = new Node<T> { Data = value, Previous = current, Next = null };
        }
    }

    public T Pop()
    {
        var current = _head;
        if (current == null) 
            throw new InvalidOperationException("Deque is empty");
        
        while (current.Next != null)
            current = current.Next;

        if (current.Previous != null)
            current.Previous.Next = null;
        else
            _head = null; // if there was only one node
        
        return current.Data;
    }

    public void Unshift(T value)
    {
        var node = new Node<T> { Data = value, Previous = null, Next = _head };
        if (_head != null)
            _head.Previous = node;

        _head = node;
    }

    public T Shift()
    {
        if (_head == null) throw new InvalidOperationException("Deque is empty");
        var data = _head.Data;
        _head = _head.Next;
        return data;
    }
}