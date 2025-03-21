namespace Change;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target == 0) return [];
        if (target < 0 || target < coins.Min())
            throw new ArgumentException(null, nameof(target));
        
        var coinsUsed = GetMinimumCoins(coins, target);
        if (coinsUsed.Length == 0) throw new ArgumentException(null, nameof(target));
        return coinsUsed;
    }
    
    private static int[] GetMinimumCoins(int[] coins, int amount)
    {
        Dictionary<int, int> memo = [];
        Dictionary<int, int> coinsUsed = [];

        var minCoins = MinCoins(coins, amount, memo, coinsUsed);
        if (minCoins == int.MaxValue)
            return []; // No solution exists

        // Backtrack to find the coins used
        List<int> coinsList = [];
        while (amount > 0)
        {
            if (!coinsUsed.TryGetValue(amount, out var coin))
                return []; // Edge case, should never happen

            coinsList.Add(coin);
            amount -= coin;
        }

        return coinsList.ToArray();
    }

    private static int MinCoins(int[] coins, int amount, Dictionary<int, int> memo, Dictionary<int, int> coinUsed)
    {
        if (amount == 0) return 0;
        if (amount < 0) return int.MaxValue;

        if (memo.ContainsKey(amount)) return memo[amount];

        var minCoins = int.MaxValue;
        var bestCoin = -1;

        foreach (var coin in coins)
        {
            var subResult = MinCoins(coins, amount - coin, memo, coinUsed);
            if (subResult != int.MaxValue && subResult + 1 < minCoins)
            {
                minCoins = subResult + 1;
                bestCoin = coin;
            }
        }

        memo[amount] = minCoins;
        if (bestCoin != -1) coinUsed[amount] = bestCoin;

        return minCoins;
    }
}