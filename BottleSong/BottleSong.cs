namespace BottleSong;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        if (takeDown <= 0 || startBottles <= 0) yield break;

        var bottles = startBottles > 1 ? "bottles" : "bottle";
        yield return $"{ToWord(startBottles)} green {bottles} hanging on the wall,";
        yield return $"{ToWord(startBottles)} green {bottles} hanging on the wall,";

        yield return "And if one green bottle should accidentally fall,";
        yield return $"There'll be {RemainingBottles(--startBottles)} hanging on the wall.";

        if (--takeDown < 1)
            yield break;

        yield return "";
        foreach (var str in Recite(startBottles, takeDown))
            yield return str;
    }

    private static string ToWord(int number) => number switch
    {
        10 => "Ten",
        9 => "Nine",
        8 => "Eight",
        7 => "Seven",
        6 => "Six",
        5 => "Five",
        4 => "Four",
        3 => "Three",
        2 => "Two",
        1 => "One",
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, null)
    };

    private static string RemainingBottles(int number) => number switch
    {
        >= 2 => $"{ToWord(number)} green bottles".ToLowerInvariant(),
        1 => "one green bottle",
        _ => "no green bottles"
    };
}