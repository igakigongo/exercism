using System.Text;

namespace RunLengthEncoding;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var sb = new StringBuilder();
        var prev = input[0];
        int i = 0, count = 0;

        while (i < input.Length)
        {
            if (input[i] == prev)
            {
                count++;
                i++;
            }
            else
            {
                sb.Append(count > 1 ? $"{count}{prev}" : prev);
                prev = input[i];
                count = 0;
            }
        }

        sb.Append(count > 1 ? $"{count}{prev}" : prev);

        return sb.ToString();
    }

    public static string Decode(string input)
    {
        var sb = new StringBuilder();
        var span = input.AsSpan();
        for (int i = 0, j = 0; i < span.Length; i++)
        {
            var ch = span[i];
            if (!char.IsLetter(ch) && !char.IsWhiteSpace(ch)) continue;

            var amt = span[j..i].IsWhiteSpace() ? 1 : int.Parse(span[j..i]);
            sb.Append(new string(ch, amt));
            j = i + 1;
        }

        return sb.ToString();
    }
}
