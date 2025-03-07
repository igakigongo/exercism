namespace PythagoreanTriplet;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        int maxA = sum / 3, maxB = sum / 2;
        
        for (var a = 1; a < maxA; a++)
        for (var b = a + 1; b < maxB; b++)
        {
            var c = sum - a - b;
            if (a + b < c) continue;
            if (a * a + b * b == c * c) yield return (a, b, c);
        }
    }
}