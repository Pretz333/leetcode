public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // Set up a HashSet, a fast way of storing unique values.
        // Adding or checking if something is inside is an O(1) operation.
        HashSet<char> charactersInSubstring = new HashSet<char>();
        
        // Start the beginning of our substring at the furthest left of the provided string
        int leftSubstringBound = 0;
        
        // Keep a record of the longest substring we've recreated
        int longestSubstring = 0;
        
        // Step through s, an O(n) operation
        for(int i=0; i < s.Length; i++) {
            // If the current character we're examining is in the set, remove the
            // leftmost character in our substring until it is no longer in the set.
            // We remove the leftmost character to ensure our substring is contiguous,
            // otherwise it would not be contiguous and would be multiple substrings.
            while(!charactersInSubstring.Add(s[i])) { // O(1)
                charactersInSubstring.Remove(s[leftSubStringBound]); // O(1)
                leftSubstringBound++;
            }
            
            // Only reassign the longest substring value if the current substring, calculated as the
            // current character of s we're examining minus the left bound of our substring plus 1.
            // As an example, let's say we're looking at the third character of s (index 2) and our
            // left bound is the first character (index 0). This would result in 2 - 0, which is 2. 
            // However, the actual length of our substring is 3 (indices 0, 1, and 2), so we add 1.
            longestSubstring = Math.Max(longestSubstring, i - leftSubstringBound + 1);
        }
        
        return longestSubstring;
    }
}