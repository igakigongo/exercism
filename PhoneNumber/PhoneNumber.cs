using System.Text.RegularExpressions;

namespace PhoneNumber;

public static class PhoneNumber
{
    private static readonly Regex Regex = new("^1?([2-9][0-9]{2}){2}[0-9]{4}$");
    
    public static string Clean(string phoneNumber)
    {
        ArgumentException.ThrowIfNullOrEmpty(phoneNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);

        var phone = new string(phoneNumber
            .Where(char.IsDigit).ToArray());

        if (phone.Length is > 11 or < 10) 
            throw new ArgumentException(null, nameof(phoneNumber));

        return Regex.IsMatch(phone)
            ? phone[^10..]
            : throw new ArgumentException(null, nameof(phoneNumber));
    }
}