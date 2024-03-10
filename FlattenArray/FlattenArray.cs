using System.Collections;

namespace FlattenArray;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var res = new List<int>();
        FlattenHelper(res, input);
        return res;
    }

    private static void FlattenHelper(ICollection<int> res,
        IEnumerable input)
    {
        var enumerator = input.GetEnumerator();
        using var disposable = enumerator as IDisposable;
        while (enumerator.MoveNext())
            switch (enumerator.Current)
            {
                case IEnumerable enumerable:
                    FlattenHelper(res, enumerable);
                    break;
                case int current:
                    res.Add(current);
                    break;
                default:
                    continue;
            }
    }
}
