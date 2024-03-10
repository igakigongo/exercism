using System.Collections;

namespace FlattenArray;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var ele in input)
            switch (ele)
            {
                case IEnumerable enumerable:
                    foreach (var element in Flatten(enumerable))
                        yield return element;
                    break;
                case int current:
                    yield return current;
                    break;
            }
    }
}
