public class Solution {
    public int CountSubstrings(string s) {
        int result = 0;
        int left, right;
        
        for(int i=0; i < s.Length; i++) {
            left = i;
            right = i;
            
            while(left >= 0 && right < s.Length && s[left] == s[right]){
                result++;
                left--;
                right++;
            }
            
            left = i;
            right = i + 1;
            while(left >= 0 && right < s.Length && s[left] == s[right]){
                result++;
                left--;
                right++;
            }
        }
        
        return result;
    }
}