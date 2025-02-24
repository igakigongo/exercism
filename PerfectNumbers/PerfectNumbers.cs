namespace PerfectNumbers;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number, nameof(number));
        if (number == 1) return Classification.Deficient;

        var factors = GetFactors(number);
        var sum = factors.Sum(x => x);

        return sum.CompareTo(number) switch
        {
            < 0 => Classification.Deficient,
            > 0 => Classification.Abundant,
            _ => Classification.Perfect
        };
    }

    private static HashSet<int> GetFactors(int number)
    {
        HashSet<int> factors = [1];
        
        var max = number / 2 + 1;
        for (var i = 2; i < max; i++)
        {
            if (number % i != 0) continue;

            factors.Add(i);
            factors.Add(number / i);
        }

        return factors;
    }
}