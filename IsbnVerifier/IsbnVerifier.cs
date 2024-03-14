using System.Text.RegularExpressions;

namespace IsbnVerifier;

public static class IsbnVerifier
{
    private static readonly Regex Regex = new(@"^\d-?\d{3}-?\d{5}-?[\dX]$");

    private static IEnumerable<int> GetIsbnDigits(string number)
    {
        foreach (var ch in number)
            if (ch == 'X') yield return 10;
            else if (char.IsDigit(ch)) yield return ch - 48;
    }

    public static bool IsValid(string number)
    {
        if (!Regex.IsMatch(number)) return false;
        var nums = GetIsbnDigits(number).ToArray();
        Array.Reverse(nums);

        int count = 0, position = 1, sum = 0;
        foreach (var num in nums)
        {
            sum += num * position++;
            if (count++ == 10) break;
        }

        return sum > 0 && sum % 11 == 0;
    }
}
