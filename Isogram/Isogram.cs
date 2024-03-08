namespace Isogram;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        Span<int> span = stackalloc int[26];

        foreach(var ch in word)
            if (ch >= 97 && ch <= 122 || ch >= 65 && ch <= 90)
                span[char.ToLower(ch) - 97]++;

        foreach (var count in span)
            if (count > 1)
                return false;

        return true;
    }
}
