namespace RotationalCipher;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        Span<char> span = stackalloc char[text.Length];
        for (var i = 0; i < text.Length; i++)
        {
            var ch = text[i];
            if (char.IsLetter(ch))
            {
                var bas = char.IsUpper(ch) ? 65 : 97;
                var res = (ch - bas + shiftKey) % 26;
                span[i] = (char)(res + bas);
            }
            else
                span[i] = ch;
        }

        return new string(span);
    }
}
