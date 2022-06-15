public class Solution {
    public int LongestStrChain(string[] words) {
        // Sort the array by length
        Array.Sort(words); // O(nlogn)
        
        // Create a dictionary to store the longest chain for each word
        Dictionary<string, int> wordMap = new Dictionary<string, int>();
        
        // Create a result variable to store the longest chain and a wordMax variable to store
        // the compared word's chain. 
        // There's probably a better way to do this, and it probably uses a lambda expression.
        int result = 0;
        int wordMax = 0;
        
        // Loop through the array
        foreach(string word in words) { // O(n)
            // Add the word to the dictionary with a value of 1, as this is it's first appearance
            wordMap.Add(word, 1);
            
            // Remove each character from the word and check if it's in the dictionary.
            for(int i=0; i<word.Length; i++) { // O(n)
                StringBuilder current = new StringBuilder(word);
                string modded = current.Remove(i, 1).ToString();
                
                // If it is, check which is longer, the current word's chain or the compared
                // word's chain with one more step (adding the character we just removed)
                if(wordMap.ContainsKey(modded)) {
                    // Once again, there's probably a better way to do this.
                    int currentVal = 0;
                    int compareVal = 0;
                    wordMap.TryGetValue(word, out currentVal);
                    wordMap.TryGetValue(modded, out compareVal);

                    // If the current word's chain is longer, update the Dictionary
                    if(currentVal < compareVal + 1) {
                        // C# doesn't have a built-in update function, so we'll remove and re-add it
                        wordMap.Remove(word);
                        wordMap.Add(word, Math.Max(currentVal, compareVal + 1));
                    }
                }
            }
            
            // Check if the current word's chain is larger than the result, and update it if so
            wordMap.TryGetValue(word, out wordMax);
            result = Math.Max(result, wordMax);
        }
        
        // Return the longest chain
        return result;
    }
}