namespace NeedForSpeed;

public class RemoteControlCar(int speed, int batteryDrain)
{
    private int _batteryPercent = 100;
    private int _distanceDriven;

    public bool BatteryDrained() => _batteryPercent < batteryDrain;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (BatteryDrained()) return;

        _distanceDriven += speed;
        _batteryPercent -= batteryDrain;
    }

    public int Drain => batteryDrain;
    public int Speed => speed;

    public static RemoteControlCar Nitro() => new(50, 4);
}

public class RaceTrack(int distance)
{
    public bool TryFinishTrack(RemoteControlCar car)
    {
        var requiredDrives = (int)Math.Ceiling((decimal)distance / car.Speed);
        return requiredDrives * car.Drain <= 100;
    }
}
