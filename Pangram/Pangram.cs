namespace Pangram;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        Span<int> span = stackalloc int[26];

        foreach (var ch in input)
            if (ch >= 97 && ch <= 122 || ch >= 65 && ch <= 90)
                span[char.ToLower(ch) - 97] = 1;

        foreach(var i in span)
            if (i == 0)
                return false;

        return true;
    }
}
