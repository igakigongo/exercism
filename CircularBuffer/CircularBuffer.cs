namespace CircularBuffer;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private readonly int _capacity;
    private int _head = -1, _tail = -1;

    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
        _capacity = capacity;
    }

    public T Read()
    {
        if (_tail == -1) throw new InvalidOperationException();
        var element = _buffer[_tail];

        if (Count - 1 == 0)
            _head = _tail = -1;
        else
            _tail = (_tail + 1) % _capacity;

        Count -= 1;
        return element;
    }

    public void Write(T value)
    {
        var next = (_head + 1) % _capacity;
        if (next == _tail) throw new InvalidOperationException();

        if (_head == -1)
        {
            _tail = next;
        }

        _head = next;
        _buffer[_head] = value;
        Count += 1;
    }

    public void Overwrite(T value)
    {
        if (!IsFull)
        {
            Write(value);
        }
        else
        {
            var next = (_head + 1) % _capacity;
            _tail = (_head + 2) % _capacity;

            _head = next;
            _buffer[_head] = value;
        }
    }

    public void Clear()
    {
        Array.Clear(_buffer);
        _head = _tail = -1;
        Count = 0;
    }

    private int Count { get; set; }

    private bool IsFull => Count == _capacity;
}