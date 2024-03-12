namespace FootballMatchReports;

public class Manager(string name, string? club)
{
    public string Name { get; } = name;
    public string? Club { get; } = club;
}

public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

public class Injury(int player) : Incident
{
    public override string GetDescription() => $"Player {player} is injured.";
}
