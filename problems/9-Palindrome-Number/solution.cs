public class Solution {
    public bool IsPalindrome(int x) {
        // We'll start with doing this the intuituive way, and then see if we can do it in a better way.

        // Convert the number to a string.
        string s = x.ToString();
        
        // Loop through the string.
        for(int i=0; i<s.Length; i++) { // O(n)
            // If the first character is not equal to the last character, return false.
            if(s[i] != s[s.Length-(i+1)]) {
                return false;
            }
        }
        
        // If we get here, the number is a palindrome.
        return true;
    }
}