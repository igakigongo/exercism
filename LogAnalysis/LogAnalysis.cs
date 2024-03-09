namespace LogAnalysis;

public static class LogAnalysis
{
    private const StringComparison Comp = StringComparison.OrdinalIgnoreCase;

    public static string SubstringAfter(this string logLine, string fragment)
    {
        var len = fragment.Length;
        var beginIndex = logLine.IndexOf(fragment, Comp) + len;
        return logLine[beginIndex..];
    }

    public static string SubstringBetween(this string logLine, string begin,
        string end)
    {
        var len = begin.Length;
        var beginIndex = logLine.IndexOf(begin, Comp) + len;
        var endIndex = logLine.IndexOf(end, Comp);
        return logLine[beginIndex..endIndex];
    }

    public static string Message(this string logLine) =>
        logLine.SubstringAfter(":").Trim();

    public static string LogLevel(this string logLine) =>
        logLine.SubstringBetween("[", "]");
}
