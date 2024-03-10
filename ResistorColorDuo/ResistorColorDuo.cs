using System.Diagnostics.CodeAnalysis;

namespace ResistorColorDuo;

[SuppressMessage("ReSharper", "UnusedMember.Local")]
public static class ResistorColorDuo
{
    private enum Color
    {
        Black = 0,
        Brown = 1,
        Red = 2,
        Orange = 3,
        Yellow = 4,
        Green = 5,
        Blue = 6,
        Violet = 7,
        Grey = 8,
        White = 9
    }

    private static int GetColor(string color) =>
        (int)Enum.Parse(typeof(Color), color, true);

    public static int Value(string[] colors) =>
        GetColor(colors[0]) * 10 + GetColor(colors[1]);
}
