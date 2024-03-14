namespace NthPrime;

public static class NthPrime
{
    public static int Prime(int nth) => nth > 0
        ? GeneratePrimesToN(nth).ToArray()[^1]
        : throw new ArgumentOutOfRangeException(nameof(nth));

    private static IEnumerable<int> GeneratePrimesToN(int n)
    {
        var count = 0;
        var curr = 2;
        while (true)
        {
            if (count == n) yield break;
            if (IsPrime(curr))
            {
                count++;
                yield return curr;
            }

            curr++;
        }
    }

    private static bool IsPrime(int n)
    {
        if (n is 2) return true;
        if ((n & 1) == 0) return false;
        var limit = (int)Math.Sqrt(n);

        var i = 2;
        while (i <= limit)
        {
            if (n % i == 0) return false;
            i += (i & 1) == 0 ? 1 : 2; // skip factors of 2
        }

        return true;
    }
}
