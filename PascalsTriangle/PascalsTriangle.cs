namespace PascalsTriangle;

public static class PascalsTriangle
{
    private static readonly Dictionary<int, int> Hash = new();

    private static int Factorial(int n)
    {
        if (Hash.TryGetValue(n, out var factorial)) return factorial;
        if (n <= 1) return 1;

        Hash[n] = n * Factorial(n - 1);
        return Hash[n];
    }

    private static IEnumerable<int> GetCoefficients(int row)
    {
        var n = row - 1;
        var factN = Factorial(n);
        for (var r = 0; r <= n; r++)
            yield return factN / (Factorial(r) * Factorial(n - r));
    }


    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows == 0)
            yield break;

        for (var row = 1; row <= rows; row++)
            yield return GetCoefficients(row);
    }
}
