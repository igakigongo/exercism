namespace PhoneNumberAnalysis;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var tokens = phoneNumber.Split('-');
        return (tokens[0] == "212", tokens[1] == "555", tokens[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        => phoneNumberInfo.IsFake;
}
