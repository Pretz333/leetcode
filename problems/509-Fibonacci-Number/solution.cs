public class Solution {
    public int Fib(int n) {
        // Quick bypass for n = 0 and n = 1
        if(n <= 1) {
            return n;
        }
        
        // Since we only need to return the sum of the last two
        // numbers, we can store the two of them in a variables.
        // This allows for an O(1) space complexity.
		int a = 0, b = 1;
		
        // Iterate through the remaining n - 2 numbers
		for(int i = n; i > 1; i--) {
            // Calculate the sum of the last two numbers. Note that we 
            // cannot store the sum directly into b as we need to keep
            // track of both the sum and the second largest number.
			int sum = a + b;
			a = b; // store the larger number in a
			b = sum; // store the sum in b
		}
        
        // Return the result of the sum of the last two numbers
        return b;

        // Time complexity: O(n)
        // Space complexity: O(1)
    }
}