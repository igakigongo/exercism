using System.Collections;

namespace BinarySearchTree;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;
    public BinarySearchTree(IEnumerable<int> values)
    {
        var arr = values.ToArray() ?? throw new ArgumentNullException(paramName: nameof(values));
        if (arr.Length == 0) throw new ArgumentException("values can not be empty", nameof(values));

        Value = arr[0];
        for (var i = 1; i < arr.Length; i++)
            Add(arr.ElementAt(i));
    }

    public int Value { get; }
    public BinarySearchTree? Left { get; private set; }
    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left != null) 
                return Left.Add(value);
            
            Left = new BinarySearchTree(value);
            return Left;
        }

        if (Right != null) return Right.Add(value);

        Right = new BinarySearchTree(value);
        return Right;
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var tree in Left?.AsEnumerable() ?? [])
            yield return tree;
        
        yield return Value;
        
        foreach (var tree in Right?.AsEnumerable() ?? [])
            yield return tree;
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}