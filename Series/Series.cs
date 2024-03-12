namespace Series;

public static class Series
{
    public static IEnumerable<string> Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0 || sliceLength > numbers.Length)
            throw new ArgumentException("invalid slice length",
                nameof(sliceLength));

        for (var i = 0; i <= numbers.Length - sliceLength; i++)
            yield return numbers[i..(i + sliceLength)];
    }
}
