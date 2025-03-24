using System.Text.RegularExpressions;

namespace Luhn;

public static class Luhn
{
    private static readonly Regex Regex = new(@"^[0-9\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static bool IsValid(string number)
    {
        number = number.Trim();
        if (string.IsNullOrEmpty(number) || number == "0" || !Regex.IsMatch(number)) 
            return false;
        
        var second = false;
        var sum = 0;

        for (var i = number.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(number[i])) continue;
            var num = second ? (number[i] - '0') * 2 : number[i] - '0';
            sum += num > 9 ? num - 9 : num;
            second = !second;
        }

        return sum % 10 == 0;
    }
}