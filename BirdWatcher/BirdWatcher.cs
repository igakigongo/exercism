namespace BirdWatcher;

public class BirdCount(int[] birdsPerDay)
{
    private static readonly int[] LastWeekStats = [0, 2, 5, 3, 7, 8, 4];

    public static int[] LastWeek() => LastWeekStats;

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => birdsPerDay.Any(x => x == 0);

    public int CountForFirstDays(int numberOfDays)
    {
        var sum = 0;
        for (var i = 0; i < numberOfDays; i++) sum += birdsPerDay[i];
        return sum;
    }

    public int BusyDays() => birdsPerDay.Count(x => x >= 5);
}
