namespace Anagram;

public class Anagram(string baseWord)
{
    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> results = new List<string>();
        Span<int> span = stackalloc int[26];

        foreach (var word in potentialMatches)
        {
            if (word.Length != baseWord.Length) continue;
            if (string.Equals(word, baseWord, StringComparison.OrdinalIgnoreCase)) continue;

            // add values from base word
            span.Clear();
            foreach (var c in baseWord)
            {
                var index = char.ToLowerInvariant(c) % 97;
                span[index]++;
            }

            // reduce the contents from the current word
            foreach (var c in word)
            {
                var index = char.ToLowerInvariant(c) % 97;
                span[index]--;
            }

            if (IsEmpty(span)) results.Add(word);
        }

        return results.ToArray();
    }

    private static bool IsEmpty(Span<int> span)
    {
        for (var i = 0; i < 26; i++)
        {
            if (span[i] != 0) return false;
        }

        return true;
    }
}
