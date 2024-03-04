using System.Text.RegularExpressions;

namespace Bob;

public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (string.IsNullOrWhiteSpace(statement) ||
            string.IsNullOrEmpty(statement) ||
            IsWhiteSpace(statement))
            return "Fine. Be that way!";

        uint result = 0b_0;
        if (IsQuestion(statement)) result |= 0b_1; // 1
        if (IsYelling(statement)) result |= 0b_10; // 2

        return result switch
        {
            0b_1 => "Sure.",
            0b_10 => "Whoa, chill out!",
            0b_11 => "Calm down, I know what I'm doing!", // 3
            _ => "Whatever."
        };
    }

    private static bool IsQuestion(string statement) =>
        statement[^1] == '?';

    private static bool IsYelling(string statement)
    {
        var letters = statement.Where(IsLetter).ToList();
        return letters.Count != 0 && letters.All(IsUpperCaseLetter);
    }

    private static bool IsLetter(char c) =>
        IsLowerCaseLetter(c) || IsUpperCaseLetter(c);

    private static bool IsLowerCaseLetter(char c) =>
        c >= 97 && c <= 122;

    private static bool IsUpperCaseLetter(char c) =>
        c >= 65 && c <= 90;

    private static bool IsWhiteSpace(string statement) =>
        new Regex(@"^[\s\r\n\t]+$", RegexOptions.Compiled).IsMatch(statement);
}
