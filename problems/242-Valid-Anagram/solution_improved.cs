public class Solution {
    public bool IsAnagram(string s, string t) {
        // NOTE: On the csresult_improved image, both times shown are from this implementation.
        // The only difference was doing if (condition) { return false;} instead of if (condition) return false;
        
        
        
        // If s and t are not the same length, they cannot be anagrams of each other.
        if (s.Length != t.Length) {
            return false;
        }

        // Dictionaries are so much faster than regular Lists that this abomination is somehow 5x faster.
        // We're essentially going to count how many of each character appears, and see if the numbers match at the end.
        // First, make the dictionaries to store these counts.
        Dictionary<char, int> sChars = new Dictionary<char, int>();
        Dictionary<char, int> tChars = new Dictionary<char, int>();

        // For each character in string each string, add 1 to the appearance counter.
        // We have to check if that entry is already in, as if it is, it'll throw an 
        // ArgumentException if we try to add a duplicate key. If that character has
        // been spotted before, we'll increment the counter. If not, we'll add it.
        // Note: we know s.Length == t.Length due to the if check above.
        for (int i = 0; i < s.Length; i++) {
        for (int i = 0; i < s.Length; i++) {
            if (sChars.ContainsKey(s[i])) { 
                sChars[s[i]] += 1;
            } else {
                sChars.Add(s[i], 1);
            }

            if (tChars.ContainsKey(t[i])) {
                tChars[t[i]] += 1;
            } else { 
                tChars.Add(t[i], 1);
            }
        }

        // For each character that is in the Dictionary, check that:
        // 1. The t Dictionary also has it
        // 2. The count of that character in equal in s and t.
        // If it is not, we'll return false.
        foreach(KeyValuePair<char,int> c in sChars) {
            if(!(tChars.ContainsKey(c.Key) && sChars[(char)c.Key] == tChars[(char)c.Key])) return false;
        }

        // If we've made it here, they are anagrams of each other.
        return true;
    }
}