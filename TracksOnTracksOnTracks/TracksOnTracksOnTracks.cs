namespace TracksOnTracksOnTracks;

public static class Languages
{
    private const StringComparison StringComp = (StringComparison)1;

    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages() =>
        ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages,
        string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Any(x => string.Equals(x, language, StringComp));

    public static List<string> ReverseList(List<string> languages)
    {
        var arr = languages.ToArray();
        Array.Reverse(arr);
        return arr.ToList();
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0) return false;
        if (string.Equals(languages[0], "C#", StringComp))
            return true;
        return string.Equals(languages[1], "C#", StringComp) &&
               languages.Count <= 3;
    }

    public static List<string> RemoveLanguage(List<string> languages,
        string language)
    {
        languages.RemoveAll(x => string.Equals(x, language,
            StringComp));
        return languages;
    }

    public static bool IsUnique(List<string> languages) =>
        new HashSet<string>(languages).Count == languages.Count;
}
