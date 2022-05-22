public class Solution {
    public int CountSubstrings(string s) {
        // Result is the number of palindromic substrings
        int result = 0;

        // left and right are our "pointers" (not literal pointers) to characters as we walk through the string
        int left, right;
        
        // For each character in the string
        for(int i=0; i < s.Length; i++) { // O(n)
            // For the first check, we'll do odd-length strings. Since single characters count as valid substrings,
            // We'll initialize both left and right to the same index in the string. If we wanted to, we could
            // initialize result to s.Length and start left at i - 1 and right at i + 1, skipping all substrings of
            // length 1, since they would always be a palindrome. I've elected not to do so for readability, but I 
            // suppose it would be slightly faster.
            left = i;
            right = i;
            
            // While our left and right "pointers" are in the string's bounds, check if both of the characters they
            // are looking at are the same. If they are, add one to the result count and move again. For example,
            // let's look at the string "aaa". On the first pass of the for loop, this while loop would check if the
            // first character was equal to itself. Since they are the same, we add one and move the left to the
            // left and the right to the right. The left is now out-of-bounds (left would be -1), so we exit. On
            // the second pass of the for loop, the second character is equal to itself, so we add 1 to result and
            // move left to the left and right to the right. Now, we're checking if the first character is the same
            // as the third. We can ignore everything in the middle since we already know they are the same, and thus
            // are palindromic. Since the first character (a) and the third (a) are the same, we add one and move left
            // to the left and right to the right. Since we're out-of-bounds, we exit.
            while(left >= 0 && right < s.Length && s[left] == s[right]) { // O(n)
                // If the characters are the same increment result by 1
                result++;

                // Move left to the left and right to the right
                left--;
                right++;
            }
            
            // For the second check, we'll do even-length strings. We'll set left to i and right to i + 1. Note that this
            // doesn't check the same substring more than once, despite that it may seem that it does. For example, take 
            // a string of length 4. We start the check by looking at indices 0 and 1. When the for increments, we check
            // 1 and 2, then 2 and 3, then 3 and 4, and we've hit the end of the for loop.
            left = i;
            right = i + 1;

            // As before, we check if left and right are still in bounds, and if they are, check if the characters are the
            // same. If they are, we expand outwards and check if those characters are the same. We need not check anything
            // in between since we've already learned that they are palindromic.
            while(left >= 0 && right < s.Length && s[left] == s[right]) { // O(n)
                // If the characters are the same increment result by 1
                result++;

                // Move left to the left and right to the right
                left--;
                right++;
            }
        }
        
        // Return the result.
        return result;
        
        // The worst-case time complexity would be O(n * (n+n)), which is the same as O(n * 2n), which simplifies to O(n^2)
        // due to how Big O-notation works. Given a string with only unique characters (e.g. "abc"), it would run at O(n + n), 
        // which simplifies to O(n), but we use the worst-case as what it is.
    }
}