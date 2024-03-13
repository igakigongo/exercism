namespace InternationalCallingConnoisseur;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new();

    public static Dictionary<int, string> GetExistingDictionary() => new()
    {
        { 1, "United States of America" },
        { 55, "Brazil" },
        { 91, "India" }
    };

    public static Dictionary<int, string> AddCountryToEmptyDictionary(
        int countryCode, string countryName) => new()
    {
        { countryCode, countryName }
    };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode,
        string countryName)
    {
        existingDictionary.TryAdd(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.TryGetValue(countryCode, out var name)
            ? name
            : string.Empty;

    public static bool CheckCodeExists(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode,
        string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
            existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(
        Dictionary<int, string> existingDictionary)
    {
        var longest = string.Empty;
        foreach (var (_, value) in existingDictionary)
        {
            if (value.Length > longest.Length)
                longest = value;
        }

        return longest;
    }
}
