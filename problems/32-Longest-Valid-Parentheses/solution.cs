public class Solution {
    public int LongestValidParentheses(string s) {
        // The result, the length of the substring
        int count = 0;

        // These will count the number of '(' and ')'
        int left = 0;
        int right = 0;
        
        // The first pass will check characters going from
        // left to right along the provided string.
        for (int i = 0; i < s.Length; i++) { // O(n)
            // Add 1 based on if it's a left or a right
            if (s[i] == '(') {
                left++;
            } else {
                right++;
            }
            
            // If we have an equal amount of left and rights, we have a valid substring. 
            // Update count to be whichever is higher, the longest valid substring up to this
            // point (the current count) or the current valid substring (left + right)
            // If we have more rights than lefts, reset our valid substring counts. This 
            // will reset on substrings like "))" (we'll get the other half on the next for loop)
            if (left == right) {
                count = Math.Max(count, left + right);
            } else if (right > left) {
                left = 0;
                right = 0;
            }
        }
        
        // Reset the counters
        left = 0;
        right = 0;
        
        // The second pass will check characters going from
        // right to left along the provided string.
        for (int i = s.Length - 1; i >= 0; i--) { // O(n)
            // Add 1 based on if it's a left or a right
            if (s[i] == '(') {
                left++;
            } else {
                right++;
            }
            
            // If we have an equal amount of left and rights, we have a valid substring. 
            // Update count to be whichever is higher, the longest valid substring up to this
            // point (the current count) or the current valid substring (left + right)
            // If we have more lefts than rights, reset our valid substring counts. This 
            // will reset on substrings like "(("
            if (left == right) {
                count = Math.Max(count, left + right);
            } else if (left > right) {
                left = right = 0;
            }
        }
        
        // Return our final result
        return count;
        
        // Since the for loops are next to each other (not one inside of the other), our solution is O(n + n), which is simply O(n).
    }
}