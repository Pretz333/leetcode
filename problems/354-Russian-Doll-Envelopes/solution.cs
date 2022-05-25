public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        // First, we're going to sort the array on the width (envelopes[][0]). 
        // If the width is equal, we're going to put the larger height (envelopes[][1]) item first. 
        // By putting the larger height items first, we can ensure we always end with the smallest
        // height envelope of that width before we move onto the next width.

        // The second parameter is a method that essentially allows Array.Sort() to understand when
        // one envelope is bigger than another following the rules mentioned above. If the method 
        // returns a negative number, the first object is smaller. If it returns a positive number, 
        // the first object is larger. If it returns a 0, the two objects are treated as equal.
        Array.Sort(envelopes, (x, y) => {
            // If the widths are equal, sort the item with the bigger height as smaller.
            if(x[0] - y[0] == 0) {
              return y[1] - x[1];
            }

            // Otherwise, sort the item with the smaller width as smaller. 
            // For example, if x[0] = 4 and y[0] = 1, this will return 3, which says that x is bigger than y. 
            // If x[0] = 1 and y[0] = 4, this will return -3, which says that y is bigger than x.
            return x[0] - y[0];
        }); // O(log n), according to the C# documentation
        
        // Cache how many envelopes we have so we don't ask for it for every element in the array.
        int n = envelopes.Length;

        // To store the heights
        int[] heights = new int[n + 1];

        // To store our result. The problem specifies that envelopes.Length >= 1, so we can start it at 1.
        int result = 1;

        // Set heights[0] to be equal to the height of the first envelope.
        heights[0] = envelopes[0][1];
        
        // Since we already set result to 1 and put the height of the first envelope in heights, start from the first envelope
        for (int i = 1; i < n; i++) { // O(n)
            // Perform a BinarySearch of the heights from 0 to however many items we've put into our result, 
            // checking to see if we've already put an element of that height into the heights. 
            // If the search finds an envelope with that height, it returns the index of that envelope. 
            // Otherwise, it checks if the height is less than one or more elements in the array. 
                // If so, it returns the bitwise complement of the index of the first element that is larger than value. 
                // If not, it returns the bitwise complement of 1 plus the index of the last element.
            // https://docs.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-6.0#system-array-binarysearch(system-array-system-int32-system-int32-system-object)
            int index = Array.BinarySearch(heights, 0, result, envelopes[i][1]); // O(1)
            
            // If the height was not found in heights, the BinarySearch returns a negative number.
            if (index < 0) {
                // The number returned when the height is not found is the bitwise complement, so flip it back to the original value.
                index = ~index;
            }
            
            // Insert the height of the current envelope into heights at the index specified by the BinarySearch
            // If the height was less than one of the elements, it'll replace that element in the array.

            // For example, consider the input [[1,6],[2,3],[3,4],[4,5]]. On our first pass, result = 1 and heights[0] = 6.
            // The BinarySearch will be looking for 3, which is not in the range of 0 to result - 1 (0 at this time) of heights. 
            // Since 3 < all elements it checked (just a 6) it returns the bitwise complement of 0. We've already flipped the 
            // value returned back to regular 0 above, so we're going to insert 3 into heights[0]. On our next pass, it'll look 
            // for 4 in the range of 0 to result - 1 (still 0) of heights. Since it doesn't find a 4 and 4 > all elements it checked
            // (just a 3), it returns the bitwise complement of the index of the last element (0) plus 1 (0 + 1 = 1). 
            // We've already flipped the index returned back, so we then insert 4 as a new maximum height.

            // Essentially, we don't care if this envelope is the best starting envelope. Our sorted array of envelopes will make
            // the BinarySearch overwrite unnecessarily large envelops that get in the way, like the [1,6] from the earlier example.
            heights[index] = envelopes[i][1];

            // If we put in a new maximum height, that is a new biggest envelope,
            // which means we found a new "wrapper" for our current stack.
            if (index == result) {
                result++;
            }
        }
        
        return result;
    }
}