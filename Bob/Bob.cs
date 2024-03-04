namespace Bob;

public static class Bob
{
    public static string Response(string statement) => statement.Trim() switch
    {
        { } message when string.IsNullOrWhiteSpace(message) => "Fine. Be that way!",
        { } message when IsYelling(message) && IsQuestion(message) => "Calm down, I know what I'm doing!",
        { } message when IsYelling(message) => "Whoa, chill out!",
        { } message when IsQuestion(message) => "Sure.",
        _ => "Whatever."
    };

    private static bool IsQuestion(string statement) =>
        statement[^1] == '?';

    private static bool IsYelling(string statement)
        => statement.Any(char.IsLetter) &&
           statement.Equals(statement.ToUpperInvariant(), StringComparison.Ordinal);
}
