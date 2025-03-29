namespace Etl;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> dictionary = [];
        foreach (var (key, value) in old)
        foreach (var letter in value)
            dictionary[letter.ToLowerInvariant()] = key;

        return dictionary;
    }
}