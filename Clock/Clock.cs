namespace Clock;

public record Clock
{
    private int _hours;
    private int _minutes;

    public Clock(int hours, int minutes)
    {
        var ms = hours % 24 * 60 + minutes % 1440;
        if (ms > -1)
            Add(ms);
        else
            Subtract(ms * -1);
    }

    public Clock Add(int minutesToAdd)
    {
        AddHours(minutesToAdd / 60 % 24);
        AddMinutes(minutesToAdd % 60);
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        AddHours(-(minutesToSubtract / 60 % 24));
        AddMinutes(-minutesToSubtract % 60);
        return this;
    }

    private void AddHours(int hours)
    {
        var hrs = hours % 24;
        _hours += hrs > 0 ? hrs : hrs + 24;
        _hours %= 24;
    }

    private void AddMinutes(int minutes)
    {
        var steps = Math.Abs(minutes % 60);
        var step = minutes < 0 ? -1 : 1;
        for (var i = 0; i < steps; i++)
        {
            _minutes += step;

            switch (_minutes)
            {
                case -1:
                    _minutes = 59;
                    _hours += step;
                    break;
                case 60:
                    _minutes = 0;
                    _hours += step;
                    break;
            }

            _hours = _hours == -1 ? 23 : _hours;
            _hours = _hours == 24 ? 0 : _hours;
        }
    }

    public override string ToString()
    {
        return $"{_hours:00}:{_minutes:00}";
    }
}