namespace SquareRoot;

public static class SquareRoot
{
    public static int Root(int number)
    {
        var left = 0;
        var right = number + 1;

        while (left != right - 1)
        {
            var middle = (left + right) / 2;

            if (middle * middle <= number)
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }

        return left;
    }
}