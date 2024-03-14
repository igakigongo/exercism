namespace AllYourBase;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase <= 1 || outputBase <= 1 ||
            inputDigits.Any(x => x < 0 || x >= inputBase))
            throw new ArgumentException(
                $"Invalid bases {inputBase} {outputBase}");

        if (inputDigits.Length == 0 || inputDigits.All(x => x == 0))
            return [0];

        var baseTenValue = ToBaseTen(inputBase, inputDigits);

        var list = new Stack<int>();

        while (baseTenValue >= outputBase)
        {
            list.Push(baseTenValue % outputBase);
            baseTenValue /= outputBase;
        }

        if (baseTenValue > 0) list.Push(baseTenValue);

        return list.ToArray();
    }

    private static int ToBaseTen(int inputBase, int[] inputDigits)
    {
        var sum = 0;
        for (int i = inputDigits.Length - 1, pow = 0; i > -1; i--)
            sum += inputDigits[i] * (int)Math.Pow(inputBase, pow++);

        return sum;
    }
}
