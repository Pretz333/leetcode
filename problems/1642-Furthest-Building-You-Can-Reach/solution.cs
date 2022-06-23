public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        // The way we're going to solve this is quite simple. We're going to go
        // until we're out of bricks, and when that happens, we'll retroactively
        // use a ladder at the place where we previously used the most bricks and
        // give ourselves that many bricks back. For example, if our heights were
        // [1, 2, 0, 3, 5, 6, 8] and we were given 4 bricks and 1 ladder, we'll move like so:
        // Start at height 1
        // Use 1 brick to go to height 2 (3 bricks remaining)
        // Use 0 bricks to go to height 0 (3 bricks remaining)
        // Use 3 bricks to go to height 3 (0 bricks remaining)
        // We're out of bricks, but we have a ladder. We'll look back at the most amount of
        // bricks we've used to this point and use a ladder at that point instead.
        // We use our ladder and gain 3 bricks while (3 bricks remaining)
        // Use 2 bricks to go to height 5 (1 brick remaining)
        // Use 1 brick to go to height 6 (0 bricks remaining)
        // We've used all of our ladders and all of our bricks, so we're all done.
        // We can return what building we made it to at this point.

        // Time to actually implement it:

        // Set up a priority queue. A priority queue is a data structure that
        // stores items with a priority, and they are given back in that priority
        // order. The default is to return the item with the lowest (number) priority
        // first. I'd like it to return the item with the highest (number) priority,
        // but setting up a class to do that would be a waste for this problem.
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();

        // To get around it returning the lowest number first, we're going to subtract
        // the number from the largest number we can store in a standard int to ensure
        // the item with the highest value is always returned first.
        int highest = Int32.MaxValue;

        // Walk through the buildings. The variable i keeps track of how far we were
        // able to go
        for (int i=0; i<heights.Length-1; i++) { // O(n)
            // If the next building is shorter than the one we're on, skip everything
            if (heights[i] >= heights[i+1]) {
                continue;
            }

            // Get the height difference between the two buildings. A possible optimization
            // is to do this before the above check and check if diff <= 0, which could save
            // a bit of time fetching values at the cost of sometimes calculating this value
            // when unneeded. 
            int diff = heights[i+1] - heights[i];
           
            // Subtract the number of bricks to get to the next step
            bricks -= diff;

            // Store how many bricks we will have to use to make the next jump. The priority
            // is equal to the largest number we can be provided minus the number of bricks
            // we used. This means that if we used 3 bricks and if we used 2 million, the
            // one with 2 million will be a smaller number and thus will be given back to us
            // before the use of 3 bricks.
            heap.Enqueue(diff, highest - diff);

            // If we'll run out of bricks trying to get to the next building (i+1)
            if (bricks < 0) {
                // Use a ladder if we have one
                if (ladders > 0) {
                    // Give us back the number of bricks the largest jump to this point took
                    bricks += heap.Dequeue();

                    // Use the ladder
                    ladders--;
                } else {
                    // If we have less bricks than needed to make it to the next building (i+1)
                    // and we're out of ladders, return how far we made it
                    return i;
                }
            }
        }
 
        // If we were able to make it through the whole array, return how many buildings
        // there were minus 1, since we started on the first building.
        return heights.Length - 1;

        // Worst-case time complexity is O(n), as we have to see if we can make it to each
        // building. However, it stops when we cannot continue, meaning it is slightly more 
        // efficient than most O(n) algorithms.
    }
}