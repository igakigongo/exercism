namespace ElonsToys;

public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceInMeters;


    public static RemoteControlCar Buy()
        => new();

    public string DistanceDisplay()
        => $"Driven {_distanceInMeters} meters";

    public string BatteryDisplay()
        => _batteryPercentage == 0 ? "Battery empty" : $"Battery at {_batteryPercentage}%";

    public void Drive()
    {
        if (_batteryPercentage == 0) return;

        _distanceInMeters += 20;
        _batteryPercentage -= 1;
    }
}
