namespace CryptoSquare;

public static class CryptoSquare
{
    private static string NormalizedPlaintext(string plaintext) => new(plaintext
        .Where(char.IsLetterOrDigit)
        .Select(char.ToLower).ToArray());

    public static string Ciphertext(string plaintext)
    {
        var normalizedPlaintext = NormalizedPlaintext(plaintext);
        var (rows, cols) = GetSquareDimensions(normalizedPlaintext.Length);

        var len = normalizedPlaintext.Length;
        var words = new List<string>();

        for (var row = 0; row < rows; row++)
        {
            var str = new char[cols];
            for (var col = 0; col < cols; col++)
            {
                var idx = col * rows + row;
                var ch = idx < len ? normalizedPlaintext[idx] : ' ';
                str[col] = ch;
            }

            words.Add(new string(str));
        }

        return string.Join(" ", words);
    }

    private static (int r, int c) GetSquareDimensions(int limitOfArea)
    {
        int r = (int)Math.Floor(Math.Sqrt(limitOfArea)), c = r;
        while (true)
        {
            if (r * c >= limitOfArea) break;
            c += 1;
            if (r * c >= limitOfArea) break;
            r++;
        }

        return r > c ? (r, c) : (c, r);
    }
}