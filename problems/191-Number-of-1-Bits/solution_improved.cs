public class Solution {
    public int HammingWeight(uint n) {
        // This solution is focused on improving the original solution from solution.cs.

        // Changing this to an int saves us a type case at the end.
        int count = 0;
        
        // Changing this to != saved 10 ms.
        while(n != 0) { // Worst-case, O(number of bits).
            // Changing count to an int means we have to rework this. Now, we check if n is odd, 
            // as odd numbers have a 1 in the rightmost bit. If it is odd, then we add 1 to count.
            // Making this change (along with changing from a uint to an int) saved 4 ms, 
            // which could be due to external factors.
            // However, my original implementation did not have the parathese (e.g. n % 2 == 1 ? 1 : 0)
            // Adding the parathese saved 13 ms, on top of the 4 from before.
            count += ((n % 2) == 1) ? 1 : 0;

            // Shift all bits to the right.
            n >>= 1;
        }
        
        return count;
    }
}