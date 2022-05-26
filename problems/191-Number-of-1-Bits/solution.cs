public class Solution {
    public int HammingWeight(uint n) {
        // This will store our result, which is the number of 1 bits.
        uint count = 0;
        
        // While n has a 1 in it (if all bits are 0, then n is 0).
        while(n > 0) { // Worst-case, O(number of bits).
            // If the rightmost bit is 1, then we have a 1 bit.
            // We can shift n to the right and add 1 to count.
            count += n & 1; // Bitwise AND with 1 will check if the rightmost bit is 1.
            n >>= 1; // Shift all bits to the right.
        }
        
        // Return the number of 1 bits.
        return (int) count;
    }
}