public class Solution {
    public int MissingNumber(int[] nums) {
        // This time, we're doing math. Essentially, we're doing the following:
        // 1. Find the sum of the numbers in the array.
        // 2. Find the sum of the numbers from 0 to nums.Length.
        // 3. Subtract the two sums.
        // 4. Return the difference, which is our missing number.

        // Find the sum of the numbers in the array.
        int sum = 0;
        foreach (int num in nums) {  // O(n)
            sum += num;
        }
        
        // Find the sum of the numbers from 0 to nums.Length.
        // This is a bit more complicated than it needs to be, because we're
        // doing the addition version of a factorial, which is called the nth
        // triangle number. I found this formula on math StackExchange.
        // https://math.stackexchange.com/questions/593318/factorial-but-with-addition
        // In particular, I found one image particularily intuitive, so I added to this
        // folder. It came from the user akinuri on math StackExchange:
        // https://math.stackexchange.com/users/113519/akinuri
        int actualSum = (nums.Length * (nums.Length + 1)) / 2;
        
        return actualSum - sum;

        // This is simply now an O(n) solution, with O(1) space complexity.
        // As an aside, I was getting incredibly inconsitent submission results, 
        // so I gave up. I was getting anywhere from 39 MB - 44 MB of memory usage, 
        // as well as everything from 88 ms - 187 ms.
    }
}