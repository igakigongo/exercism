namespace SumOfMultiples;

public static class SumOfMultiples
{
    public static int Sum(int[] multiples, int max)
    {
        if (multiples.Length == 0) return 0;

        var mults = new HashSet<int>();
        foreach (var factor in multiples)
        {
            if (factor == 0) continue;
            for (var i = factor; i < max; i += factor)
                mults.Add(i);
        }

        return mults.Sum();
    }
}
