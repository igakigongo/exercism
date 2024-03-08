namespace Acronym;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var punctuationMet = true;
        var result = string.Empty;

        foreach (var ch in phrase)
            if (char.IsWhiteSpace(ch) || ch == '-')
                punctuationMet = true;
            else if (char.IsLetter(ch) && punctuationMet)
            {
                result += char.ToUpper(ch);
                punctuationMet = false;
            }

        return result;
    }
}
