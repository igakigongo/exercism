using System.Collections;

namespace Sieve;

public static class Sieve
{
    public static IEnumerable<int> Primes(int limit)
    {
        var array = new BitArray(limit + 1, true);

        for (var i = 2; i <= limit; i++)
        {
            if (array[i] == false) continue;
            for (var j = i * 2; j <= limit; j += i)
                array[j] = false;

            yield return i;
        }
    }
}