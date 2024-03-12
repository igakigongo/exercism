namespace AtbashCipher;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        var list = new List<char>();
        var i = 0;
        foreach (var ch in plainValue)
        {
            if (char.IsDigit(ch)) list.Add(ch);
            if (ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)
                list.Add((char)(122 + 97 - char.ToLower(ch)));

            if (list.Count > 0 && list.Count == (i + 1) * 5 + i)
            {
                list.Add(' ');
                i++;
            }
        }

        if (list[^1] == ' ') list.RemoveAt(list.Count - 1);
        return new string(list.ToArray());
    }

    public static string Decode(string encodedValue)
    {
        var list = new List<char>();
        foreach (var ch in encodedValue)
        {
            if (char.IsDigit(ch)) list.Add(ch);
            if (ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122)
                list.Add((char)(122 + 97 - char.ToLower(ch)));
        }

        return new string(list.ToArray());
    }
}
