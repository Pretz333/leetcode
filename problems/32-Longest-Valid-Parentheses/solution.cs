public class Solution {
    public int LongestValidParentheses(string s) {
        int count = 0;
        
        int left = 0;
        int right = 0;
        
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                left++;
            }
            
            if (s[i] == ')') {
                right++;
            }
            
            if (left == right) {
                count = Math.Max(count, left + right);
            } else if (right > left) {
                left = 0;
                right = 0;
            }
        }
        
        left = 0;
        right = 0;
        
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '(') {
                left++;
            }
            
            if (s[i] == ')') {
                right++;
            }
            
            if (left == right) {
                count = Math.Max(count, left + right);
            } else if (left > right) {
                left = right = 0;
            }
        }
        
        return count;
    }
}