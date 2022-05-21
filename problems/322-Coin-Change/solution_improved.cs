public class Solution {
    // If you're curious about how this works, read the other one. The only difference
    // in this version is using amount + 1 instead of Int16.MaxValue. I suspected it
    // may be slower, but it was worse than I was expecting. 
    
    // Oh well, learn something new everyday.

    public int CoinChange(int[] coins, int amount) {
        int[] values = new int[amount + 1];
        Array.Fill(values, amount + 1);
        
        values[0] = 0;
        
        for(int i=1; i < amount + 1; i++) {
            foreach(int coin in coins) {
                if(i - coin >= 0) {
                    values[i] = Math.Min(values[i], values[i - coin] + 1);
                }
            }
        }
        
        return (values[amount] != amount + 1) ? values[amount] : -1;
    }
}