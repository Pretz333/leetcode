public class Solution {
    public int CoinChange(int[] coins, int amount) {
        // If we were doing a depth-first search (DFS), we'd run into many instances where we're
        // calculating the same thing twice. For example, given amount = 9 and coins = [1, 2, 3],
        // we have to check starting with every coin. Subtracting 3 leaves us with a target of 6.
        // We could also subtract a 2 and a 1 once, leaving us with 6. Following pure DFS, we'd
        // end up doing 6 - 3, 6 - 2, and 6 - 1 (and all of their subsequent subtractions) in both
        // of these cases.
        
        // The following solution attempts to skip this be starting at the bottom and working our
        // way up. For example, given amount = 9 and coins = [1, 2, 3], we want to know the least
        // amount of coins it takes to make a total of 1. And 2. And 3. Then, as we get closer to
        // the total, we can start going "okay, subtracting 3 from 6 gives me 3. What was the fewest
        // amount of coins it took to make a total of 3? 2? Okay, that means it takes 3 coins to
        // make a 6.

        // Make an array to store how many coins it takes to make each value from 0 to amount.
        // This will allow us to do something like values[7] = values[4] + values[3], or from
        // the example mentioned in the section section, 6 - 3 = 3, which means the number of
        // coins to make a 6 is 1 + values[6 - 3].
        int[] values = new int[Int16.MaxValue];

        // Pre-fill the array with some big number. If we can't make a total (such as a total of 1
        // when only given coins with values > 1), we mark it as a big number. We could do amount + 1,
        // but I've done Int16.MaxValue to make it clear that it just needs to be some big number.
        Array.Fill(values, Int16.MaxValue);
        
        // It takes 0 coins to make a value of 0.
        values[0] = 0;
        
        // For each value from 1 to amount, figure out the minimum amount of coins it takes to make
        // that value. We start at 1 as it takes 0 coins to make a value of 0.
        for(int i=1; i <= amount; i++) { // O(amount)
            // Try every coin. Sometimes, subtracting a smaller number is better in the long run.
            // For example, given amount = 7 and coins = [1, 3, 4, 5], 7 = 5 - 1 - 1 (3 coins),
            //but it is also equal to 4 - 3 (2 coins).
            foreach(int coin in coins) { // O(coins)
                // If subtracting the coin leaves us with a negative number, then that coin does not
                // help us reach the total. Instead, leave values[i] as it is and check the next coin.
                if(i - coin >= 0) {
                    // If it was non-negative, figure out how many coins it would take to get that
                    // remaining value and add 1 more coin. Keep only the smallest value, so that
                    // 6 - 3 = values[3] is not overwritten by 6 - 1 = values[5] if values[5] > values[3].
                    values[i] = Math.Min(values[i], values[i - coin] + 1);
                }
            }
        }
        
        // If we were able to find a coin total, return it. Otherwise, return -1.
        return (values[amount] != Int16.MaxValue) ? values[amount] : -1;

        // Total time complexity is O(amount * coins), as we have a for loop in a for loop.
    }
}