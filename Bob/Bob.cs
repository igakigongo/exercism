namespace Bob;

public static class Bob
{
    public static string Response(string statement)
    {
        switch (statement.Trim())
        {
            case { } message when string.IsNullOrWhiteSpace(message):
                return "Fine. Be that way!";

            case { } message when IsYelling(message) && IsQuestion(message):
                return "Calm down, I know what I'm doing!";

            case { } message when IsYelling(message):
                return "Whoa, chill out!";

            case { } message when IsQuestion(message):
                return "Sure.";

            default:
                return "Whatever.";
        }
    }

    private static bool IsQuestion(string statement) =>
        statement[^1] == '?';

    private static bool IsYelling(string statement)
        => statement.Any(char.IsLetter) &&
           statement.Equals(statement.ToUpperInvariant(), StringComparison.Ordinal);
}
