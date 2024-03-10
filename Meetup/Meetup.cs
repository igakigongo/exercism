namespace Meetup;

public enum Schedule
{
    Teenth = 13,
    First = 1,
    Second = 8,
    Third = 15,
    Fourth = 22,
    Last
}

public class Meetup(int month, int year)
{
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var start = schedule switch
        {
            Schedule.Last => new DateTime(year, month,
                DateTime.DaysInMonth(year, month) - 6),
            _ => new DateTime(year, month, (int)schedule)
        };

        while (start.DayOfWeek != dayOfWeek)
            start = start.AddDays(1);

        return start;
    }
}
