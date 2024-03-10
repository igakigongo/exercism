namespace WizardsAndWarriors;

public abstract class Character(string characterType)
{
    protected bool IsVulnerable;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => IsVulnerable;

    public override string ToString() => $"Character is a {characterType}";
}

public sealed class Warrior() : Character("Warrior")
{
    public override int DamagePoints(Character target) =>
        target.Vulnerable() ? 10 : 6;
}

public sealed class Wizard : Character
{
    private bool _hasSpell;

    public Wizard() : base("Wizard") => IsVulnerable = true;

    public override int DamagePoints(Character target) => _hasSpell ? 12 : 3;

    public void PrepareSpell()
    {
        _hasSpell = true;
        IsVulnerable = false;
    }
}
