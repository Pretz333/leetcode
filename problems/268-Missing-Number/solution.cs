public class Solution {
    public int MissingNumber(int[] nums) {
        // In order to use BinarySearch, we need to sort the array.
        Array.Sort(nums); // O(n log n)
        
        // The problem specifies that the missing number is between 0 and nums.Length.
        // Because of this, we can iterate from 0 to nums.Length - 1. If that number
        // is not in the array, it is the missing number.
        for(int i = 0; i < nums.Length; i++) { // O(n)
            // Search for the number in the array. If it is not found,
            // BinarySearch returns a negative number. For more specifics, see
            // problem 354, as in that problem, the specific number that it
            // returns actually matters. In this one, it doesn't matter. As
            // long as the number is negative, it is not in the array, and 
            // thus is the missing number.
            if(Array.BinarySearch(nums, i) < 0) { // O(log n)
                return i;
            }
        }
        
        // Technically, we should loop from 0 to nums.Length, but we stop at 
        // nums.Length - 1. This is because if we haven't found the missing
        // number yet, it must be nums.Length, so we skip it and return it here.
        // This probably isn't noticibly faster, but we have to have a return 
        // statement here anyways to avoid a compiler error, since all code
        // paths must return a value.
        return nums.Length;

        // The total time complexity is O(n log n) + O(n log n). This is because
        // we have a top-level O(n log n), as well as a O(log n) in an O(n) loop.
        // This means that we end up with O(n log n) + O(n log n), which is the 
        // same as O(2n log n^2), which is the same as O(n^2) (I think - don't
        // quote me on this. I haven't needed to work with logs in 6 years).
    }
}