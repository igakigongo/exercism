namespace Proverb;

public static class Proverb
{
    public static IEnumerable<string> Recite(string[] subjects)
    {
        if (subjects.Length == 0) yield break;
        if (subjects.Length > 1)
            for (var i = 0; i < subjects.Length - 1; i++)
                yield return
                    $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";

        yield return $"And all for the want of a {subjects[0]}.";
    }
}
