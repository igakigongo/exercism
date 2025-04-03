using System.Text;

namespace AffineCipher;

public static class AffineCipher
{
    public static string Encode(string plainText, int a, int b)
    {
        var gcd = GreatestCommonDivisor(a, 26);
        if (gcd != 1) throw new ArgumentException($"{a} and m = 26 must be co-prime.", nameof(a));

        var sb = new StringBuilder();
        var count = 0;
        foreach (var character in plainText)
        {
            if (char.IsDigit(character))
                sb.Append(character);
            else if (char.IsLetter(character))
            {
                var val = (a * (char.ToLower(character) - 'a') + b) % 26;
                sb.Append((char)(val + 'a'));
            }
            else continue;

            if (++count < 5) continue;
            sb.Append(' ');
            count = 0;
        }

        return sb.ToString().TrimEnd();
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        var gcd = GreatestCommonDivisor(a, 26);
        if (gcd != 1) throw new ArgumentException($"{a} and m = 26 must be co-prime.", nameof(a));

        var mmi = ComputeModularMultiplicativeInverse(a);
        var sb = new StringBuilder(cipheredText.Length);

        foreach (var ch in cipheredText)
            if (char.IsDigit(ch)) sb.Append(ch);
            else if (char.IsLetter(ch))
            {
                var cc = (mmi * (ch - 'a' - b) % 26 + 26) % 26;
                sb.Append((char)(cc + 'a'));
            }

        return sb.ToString();
    }

    private static int GreatestCommonDivisor(int a, int b)
    {
        if (a == 0) return b;
        if (b == 0) return a;

        return a > b ? GreatestCommonDivisor(a % b, b) : GreatestCommonDivisor(a, b % a);
    }

    private static int ComputeModularMultiplicativeInverse(int a)
    {
        var count = 1;
        for (var sum = a; sum % 26 != 1; sum += a, count++) ;

        return count;
    }
}