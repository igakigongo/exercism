namespace ResistorColorDuo;

public static class ResistorColorDuo
{
    private static readonly Dictionary<string, int> Dict = new()
    {
        { "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }
    };

    public static int Value(string[] colors) =>
        Dict[colors[0]] * 10 + Dict[colors[1]];
}
