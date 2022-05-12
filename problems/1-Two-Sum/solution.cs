public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // We need to return an array of indices of the two values
        int[] result = new int[2];
        int diff;
        
        // The problem declaration says: "You may assume that each input would have exactly one solution"
        // So save ourselves a little effort by ensuring it isn't a two-element array, 
        // as the solution would then be the input array.
        if(nums.Length == 2) // An O(1) operation
        {
            // There are only two elements, so return the (only) two indices
            return new int[] {0,1};
        }
        
        // // The O(n^2) solution
        // // Grab one of the values
        // // Starting at 1 as we cannot return the same element twice
        // for (int i=1; i < nums.Length; i++)
        // {
        //     // What number are we looking for?
        //     diff = target - nums[i];
            
        //     // Grab a second value
        //     for(int j=0; j<nums.Length; j++)
        //     {
        //         // Check if the second pulled value is the solution
        //         if(nums[j] == diff && i != j)
        //         {
        //             result[0] = i;
        //             result[1] = j;
        //             return result;
        //         }
        //     }
        // }
        
        // Set up a Dictionary, a C# HashMap. We'll be using it "backwards", 
        // where the values of the array will be the keys and the indices will be the value,
        // as Dictionary has a getter for values based on a key, but not for keys based on a value. 
        // Since we return the indices of the array, we need those as the values.
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        // Preload the first element, since we can't return it twice
        // As an example, putting the first element in the for loop would simply
        // add it to the array and try to find something that definitely does not exist
        map.Add(nums[0], 0);
        
        // Start at 1 to skip the first element
        for(int i=1; i < nums.Length; i++) // an O(n) operation
        {
            // What number are we looking for?
            diff = target - nums[i];
            
            // As mentioned before, we're looking at the key instead of the value
            // as we put in the array values into the key of the Dictionary
            if(map.ContainsKey(diff)) // an O(n) operation
            {
                result[0] = i;
                result[1] = map[diff]; // diff is the array value, but we need the index
                return result;
            }
            
            // A try-catch block is needed here as a Dictionary will throw an ArgumentException 
            // if you try to add a second element with the same key.
            try
            {
                // map.Add(array value, index of said value);
                map.Add(nums[i], i);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with key \"" + i + "\" already exists.");
            }
        }
        
        return result;
    }
}