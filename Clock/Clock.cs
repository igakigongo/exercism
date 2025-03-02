namespace Clock;

public record Clock
{
    private readonly int _hours;
    private readonly int _minutes;

    public Clock(int hours, int minutes)
    {
        var mins = hours * 60 + minutes;
        _hours = Math.DivRem(Mod(mins, 1440), 60, out _minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(_hours, _minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_hours, _minutes - minutesToSubtract);
    }

    private static int Mod(int x, int y) => (x % y + y) % y;

    public override string ToString()
    {
        return $"{_hours:00}:{_minutes:00}";
    }
}