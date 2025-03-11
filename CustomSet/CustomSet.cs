using System.Collections;

namespace CustomSet;

public class CustomSet : IEnumerable<int>
{
    private readonly SortedSet<int> _set;

    public CustomSet(params int[] values)
    {
        _set = new SortedSet<int>(values);
    }

    public CustomSet Add(int value)
    {
        var result = new int[_set.Count + 1];
        var i = 0;
        foreach (var element in _set)
            result[i++] = element;

        result[i] = value;
        return new CustomSet(result.ToArray());
    }

    public bool Empty()
    {
        return _set.Count == 0;
    }

    public bool Contains(int value)
    {
        return _set.Contains(value);
    }

    public bool Subset(CustomSet right)
    {
        return this.All(right.Contains);
    }

    public bool Disjoint(CustomSet right)
    {
        var intersection = this.Intersect(right);
        return !intersection.Any();
    }

    public CustomSet Intersection(CustomSet right)
    {
        var both = this.Intersect(right);
        return new CustomSet(both.ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
        var diff = this.Except(right);
        return new CustomSet(diff.ToArray());
    }

    public CustomSet Union(CustomSet right)
    {
        var all = _set.Union(right);
        return new CustomSet(all.ToArray());
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