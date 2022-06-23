public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // Sort the array largest to smallest
        // We use a lambda operator to specify how we want it
        // sorted, as the default sorting is smallest to largest.
        // Sorting it largest to smallest greatly simplifies the
        // return code.
        Array.Sort(nums, (a, b) => b - a); // O(n log n)

        // Return the Kth element. We have to subtract 1 as our
        // array is zero-indexed, meaning the largest element (k=1)
        // is at index 0 (index = k - 1)
        return nums[k - 1];

        // The total time complexity is O(n log n), as specified in
        // the Array.Sort() documentation.
    }
}