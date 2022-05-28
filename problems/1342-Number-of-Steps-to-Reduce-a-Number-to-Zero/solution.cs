public class Solution {
    public int NumberOfSteps(int num) {
        // Honestly, not really sure what to comment here.
        // The problem gives you the steps to solve it.

        // Count how many steps it took to get to 0.
        int steps = 0;
        
        // While we're not at zero, keep going.
        while(num != 0) {
            // If it's even, divide by 2.
            // If it's odd, subtract 1.
            if(num % 2 == 0) {
                num /= 2;
            } else {
                num--;
            }
            
            // Add one to the number of steps.
            steps++;
        }
        
        // Return how many steps it took to get to zero.
        return steps;

        // This averages out to O(n / 2) time, which is simply
        // O(n) time complexity, and O(1) space complexity.
        // This is because no matter what number we're given,
        // it will be even (and thus be halved) at least every
        // other number. Given a number like 7, this means we 
        // go 7 -> 6 -> 3 -> 2 -> 1 -> 0, which is 5 steps.
        // Basically O(n). Given a massive number, we'll see 
        // the cuts in half more ofter. For example, 128 -> 
        // 64 -> 32 -> 16 -> 8 -> 4 -> 2 -> 1 -> 0. That was 
        // 8 steps. On average, across all numbers, this is O(n).

        // As an aside, you could also solve this with some fun
        // bit manipulation. I chose not to, since my goal to have
        // easily explainable and readable code. But as an example,
        // you could do (num & 1) == 0, which is the same thing as
        // num % 2 == 0. You could also do num >>= 1, which is the
        // same as num /= 2.
    }
}