namespace InterestIsInteresting;

public static class SavingsAccount
{
    public static float InterestRate(decimal balance) => balance switch
    {
        < 0 => 3.213f,
        >= 0 and < 1000 => 0.5f,
        >= 1000 and < 5000 => 1.621f,
        _ => 2.475f
    };

    public static decimal Interest(decimal balance)
        => (decimal)InterestRate(balance) * 0.01m * balance;

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var years = 0;
        for (; balance <= targetBalance; ++years)
        {
            balance = AnnualBalanceUpdate(balance);
        }

        return years;
    }
}
