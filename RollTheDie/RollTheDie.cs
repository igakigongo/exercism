namespace RollTheDie;

public class Player
{
    private readonly Random _random = new((int)DateTime.UtcNow.Ticks);

    public int RollDie() => _random.Next(1, 18);

    public double GenerateSpellStrength() => _random.NextDouble() * 100;
}
