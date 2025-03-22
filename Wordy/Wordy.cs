using System.Text.RegularExpressions;

namespace Wordy;

public static class Wordy
{
    private static readonly Regex QnRegex = new("^What is (-?[0-9]+)\\?$");
    private static readonly Regex Regex = new("(-?[0-9]+) (plus|minus|divided by|multiplied by) (-?[0-9]+)");

    public static int Answer(string question)
    {
        if (!question.StartsWith("What is "))
            throw new ArgumentException(null, nameof(question));

        return Evaluate(question);
    }

    private static int Evaluate(string question)
    {
        var qnMatch = QnRegex.Match(question);
        if (qnMatch.Success)
            return int.Parse(qnMatch.Groups[1].Value);

        var match = Regex.Match(question);
        if (!match.Success) throw new ArgumentException(null, nameof(question));

        var num1 = int.Parse(match.Groups[1].Value);
        var num2 = int.Parse(match.Groups[3].Value);
        var op = match.Groups[2].Value;
        var answer = op switch
        {
            "plus" => num1 + num2,
            "minus" => num1 - num2,
            "multiplied by" => num1 * num2,
            "divided by" => num2 == 0 ? throw new ArgumentException(null, nameof(question)) : num1 / num2,
            _ => throw new ArgumentException(null, nameof(question)),
        };

        return Evaluate(Regex.Replace(question, answer.ToString()));
    }
}