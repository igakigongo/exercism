namespace Triangle;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3) &&
        !(side1.Equals(side2) || side2.Equals(side3) || side3.Equals(side1));

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3) &&
        (side1.Equals(side2) || side2.Equals(side3) || side3.Equals(side1));

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3) &&
        side1 > 0 && side2 > 0 && side3 > 0 &&
        side1.Equals(side2) && side2.Equals(side3);

    private static bool IsValid(double side1, double side2, double side3) =>
        side1 + side2 >= side3 &&
        side2 + side3 >= side1 &&
        side3 + side1 >= side2;
}
