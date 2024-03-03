namespace Darts;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var distanceFromCentre = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        return distanceFromCentre switch
        {
            <= 1 => 10,
            > 1 and <= 5 => 5,
            > 5 and <= 10 => 1,
            _ => 0
        };
    }
}
