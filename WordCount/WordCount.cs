using System.Text.RegularExpressions;

namespace WordCount;

public static class WordCount
{
    private static readonly Regex Regex = new(@"\b\w+[']?\w*\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static IDictionary<string, int> CountWords(string phrase)
    {
        Dictionary<string, int> dict = [];
        var matches = Regex.Matches(phrase);
        foreach (Match match in matches)
        {
            var str = match.Value.ToLowerInvariant();
            dict[str] = dict.TryGetValue(str, out var count) ? count + 1 : 1;
        }

        return dict;
    }
}