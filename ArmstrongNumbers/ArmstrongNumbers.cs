namespace ArmstrongNumbers;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var power = 1;
        while (power < number)
            power *= 10;

        power = (int)Math.Log10(power);

        double sum = 0;
        var num = number;
        while (number > 0)
        {
            var digit = number % 10;
            sum += Math.Pow(digit, power);
            number = digit == 0 ? number / 10 : (number - digit) / 10;
        }

        return (int)sum == num;
    }
}