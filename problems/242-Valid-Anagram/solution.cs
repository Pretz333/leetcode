public class Solution {
    public bool IsAnagram(string s, string t) {
        // If s and t are not the same length, they cannot be anagrams of each other.
        if(s.Length != t.Length) {
            return false;
        }
        
        // Make a list of the characters that make up each string. 
        // I'd love to use a HashSet, but we can't as it only takes unique values. 
        // This means something like the work "anagram" would break it, as there are 3 a's.
        List<char> sChars = new List<char>(s.ToCharArray());
        List<char> tChars = new List<char>(t.ToCharArray());
        
        // For each character in one of the strings (s, in this case), remove that character 
        // from the other string's (t, in this case) remaining character list.
        // If it cannot be removed, that means that one of the strings (s) had an extra character.
        foreach(char c in sChars) {
            if(!tChars.Remove(c)) return false;
        }
        
        // Return if the other string's list is empty. It being empty would mean that s and t had the
        // same amount of characters. If we simply returned true here, "racer" and "racers" would be
        // viewed as anagrams.
        return tChars.Count == 0;
    }
}