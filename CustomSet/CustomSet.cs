using System.Collections;

namespace CustomSet;

public class CustomSet : IEnumerable<int>
{
    private readonly int[] _set;

    public CustomSet(params int[] values)
    {
        var hs = new HashSet<int>(values);
        _set = hs.Select(x => x).ToArray();
        Array.Sort(_set, (a, b) => a.CompareTo(b));
    }

    public CustomSet Add(int value)
    {
        var result = new int[_set.Length + 1];
        Array.Copy(_set, result, _set.Length);
        result[_set.Length] = value;
        return new CustomSet(result);
    }

    public bool Empty()
    {
        return _set.Length == 0;
    }

    public bool Contains(int value)
    {
        return Array.IndexOf(_set, value) >= 0;
    }

    public bool Subset(CustomSet right)
    {
        var set = new HashSet<int>(right);
        var result = true;
        foreach (var element in this)
            result &= set.Contains(element);

        return result;
    }

    public bool Disjoint(CustomSet right)
    {
        var intersection = this.Intersect(right);
        return !intersection.Any();
    }

    public CustomSet Intersection(CustomSet right)
    {
        var dictionary = new Dictionary<int, int>();
        foreach (var element in this)
            dictionary.Add(element, 1);

        foreach (var element in right)
            if (dictionary.ContainsKey(element))
                dictionary[element]++;

        List<int> intersection = [];
        foreach (var (key, value) in dictionary)
            if (value == 2)
                intersection.Add(key);

        return new CustomSet(intersection.ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
        List<int> notInRight = [];
        foreach (var element in this)
            if (!right.Contains(element))
                notInRight.Add(element);

        return new CustomSet(notInRight.ToArray());
    }

    public CustomSet Union(CustomSet right)
    {
        HashSet<int> union = [];
        foreach (var element in right)
            union.Add(element);

        foreach (var element in _set)
            union.Add(element);

        return new CustomSet(union.ToArray());
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var element in _set)
            yield return element;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}