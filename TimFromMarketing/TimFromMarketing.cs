namespace TimFromMarketing;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var result = id == null ? string.Empty: $"[{id}] - ";
        result += $"{name} - {(department ?? "owner").ToUpper()}";
        return result;
    }
}
