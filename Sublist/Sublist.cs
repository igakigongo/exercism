namespace Sublist;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> first, List<T> second)
        where T : IComparable
    {
        if (first.Count == second.Count && first.SequenceEqual(second))
            return SublistType.Equal;

        if (first.Count < second.Count && second.ContainsAll(first))
            return SublistType.Sublist;

        if (first.Count > second.Count && first.ContainsAll(second))
            return SublistType.Superlist;

        return SublistType.Unequal;
    }

    private static bool ContainsAll<T>(this List<T> first, List<T> second)
    {
        var end = first.Count - second.Count;
        for (var i = 0; i <= end; i++)
            if (first.GetRange(i, second.Count).SequenceEqual(second))
                return true;

        return false;
    }
}