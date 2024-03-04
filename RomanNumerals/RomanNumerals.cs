namespace RomanNumerals;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<int, string> Map = new()
    {
        { 900, "CM" },
        { 800, "DCCC" },
        { 700, "DCC" },
        { 600, "DC" },
        { 500, "D" },
        { 400, "CD" },
        { 300, "CCC" },
        { 200, "CC" },
        { 100, "C" },
        { 90, "XC" },
        { 80, "LXXX" },
        { 70, "LXX" },
        { 60, "LX" },
        { 50, "L" },
        { 40, "XL" },
        { 30, "XXX" },
        { 20, "XX" },
        { 10, "X" },
        { 9, "IX" },
        { 8, "VIII" },
        { 7, "VII" },
        { 6, "VI" },
        { 5, "V" },
        { 4, "IV" },
        { 3, "III" },
        { 2, "II" },
        { 1, "I" },
    };

    public static string ToRoman(this int value)
    {
        var num = value;
        var result = string.Empty;
        while (num > 0)
        {
            int key;
            switch (num)
            {
                case >= 1000:
                    result += new string('M', num / 1000);
                    num %= 1000;
                    break;
                case >= 100:
                    key = 100 * (num / 100);
                    result += Map[key];
                    num -= key;
                    break;
                case >= 10:
                    key = 10 * (num / 10);
                    result += Map[key];
                    num -= key;
                    break;
                default:
                    result += Map[num];
                    num -= num;
                    break;
            }
        }

        return result;
    }
}
