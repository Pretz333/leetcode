public class Solution {
    public int[] RunningSum(int[] nums) {
        // For each element in the array starting at the 2nd element,
        // add the previous element. We start at the second element
        // as the first element will always be itself.
        for(int i = 1; i < nums.Length; i++) { // O(n)
            // += is shorthand for nums[i] += nums[i - 1].
            nums[i] += nums[i-1];
        }
        
        // Return the array.
        return nums;

        // Total time complexity is O(n), as we have a single loop that iterates
        // through the array once. 
        // Space complexity is O(1), as we're not creating any new arrays.
        // Side note: my submission had a memory spike in LeetCode where it used
        // 43MB of memory instead of the standard 41.5-ish MB. I submitted it 
        // again (since the memory usage didn't seem right) and put that result
        // in the repo as well. It's the same code both times with wildly different
        // results, leading me to wish that LeetCode was more consistent.
    }
}