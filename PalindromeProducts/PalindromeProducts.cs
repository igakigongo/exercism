namespace PalindromeProducts;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor,
        int maxFactor)
    {
        var max = new ValueTuple<int, List<(int, int)>>(int.MinValue, []);

        for (var i = minFactor; i <= maxFactor; i++)
        for (var j = i; j <= maxFactor; j++)
        {
            var pdt = i * j;
            if (!IsPalindrome(pdt)) continue;

            if (pdt > max.Item1)
                max = (pdt, [(i, j)]);

            if (pdt == max.Item1 && !max.Item2.Contains((i, j)))
                max.Item2.Add((i, j));
        }

        return max.Item1 == int.MinValue
            ? throw new ArgumentException("No palindromes products in range")
            : max;
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor,
        int maxFactor)
    {
        for (var i = minFactor; i <= maxFactor; i++)
        for (var j = i; j <= maxFactor; j++)
            if (IsPalindrome(i * j))
                return (i * j, new[] { (i, j) });

        throw new ArgumentException("No palindromes products in range");
    }


    private static bool IsPalindrome(int num)
    {
        if (num is >= 0 and <= 9) return true;
        if (num <= 99) return num % 11 == 0;
        if (num <= 999) return num % 10 == num / 100;

        var str = num.ToString();
        for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            if (str[i] != str[j])
                return false;
        return true;
    }
}
