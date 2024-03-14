namespace Accumulate;

public static class AccumulateExtensions
{
    public static IEnumerable<TU> Accumulate<T, TU>(
        this IEnumerable<T> collection, Func<T, TU> func)
    {
        foreach (var ele in collection)
            yield return func(ele);
    }
}
