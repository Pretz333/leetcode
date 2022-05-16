public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        // Apparently, try-catch blocks are slow. By doing what I wrote in the comments
        // of my original version, I reduced the runtime to 1/7th of what it was.
        // Below is the full commented source, meaning viewing the original is not necessary.
        // I've kept it for reference, and because I thought it was interesting.

        // -----------------------------------------------------------------------------------

        // The problem description stated it is an n by n grid, so we don't need to
        // check if grid.Length == grid[0].Length (if the height and width are equal)
        int n = grid.Length;
        
        // If the entrance or exit are blocked (are a 1), exit immediately.
        if(grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return -1;

        // A Queue is a simple first-in, first-out object for storing items. We'll be storing cells that
        // we can traverse (cells with a 0) in the queue using the cell's coordinates and the number
        // of steps we took to get there in this format: [steps taken, x coordinate, y coordinate].
        Queue<int[]> queue = new Queue<int[]>();

        // Add the first cell to the queue. We know it's traversable
        // (a value of 0) since it passed the if check above.
        queue.Enqueue(new int[]{1, 0, 0});

        // Set this cell to a 1 so we don't traverse over it again. If modifiying the original
        // grid is not allowed, we could also use a HashSet to store the cells we've visited.
        grid[0][0] = 1;
        
        // This is to list out which ways we can move. There are eight, which are (in order):
        // right, left, down, up, up-right, down-left, up-left, down-right.
        int[][] dirs = new int[][] {
            new int[]{0,1},
            new int[]{0,-1},
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{1, -1},
            new int[]{-1, 1},
            new int[]{-1, -1},
            new int[]{1, 1}
        };
        
        // Loop until we've either found the final cell (we'll see that exit later)
        // or until we've run out of cells to check.
        while(queue.Count > 0) {
            // Get the oldest cell in the queue, as this will complete a breadth-first search, 
            // meaning that we can be sure we've checked all possible paths for a shorter path
            // by the time we reach the ending (bottom-right) cell.
            int[] cell = queue.Dequeue();

            // As stated above, we are storing [steps taken, x coordinate, y coordinate] in the queue
            int steps = cell[0], x = cell[1], y = cell[2];

            // If this is the bottom-right cell, return how many steps it took to get here.
            if(x == n-1 && y == n-1) return steps;
            
            // Loop through all of the different directions we can take
            foreach(int[] dir in dirs) {
                // Pre-add the direction modifiers so we don't have to do it twice
                int x2 = x + dir[0];
                int y2 = y + dir[1];
                
                // Check if the new demensions are in grid's bounds, as otherwise we'll get an
                // IndexOutOfRangeException, which will crash the program. We could stick this 
                // in a try-catch block, but apparently that is slow (compare csresult.png to 
                // csresult_improved.png, the only thing that changed was the try-catch and this
                // if statement). After checking the bounds, check if the cell is traversable
                if(0 <= x2 && x2 <= n - 1 && 0 <= y2 && y2 <= n - 1 && grid[x2][y2] == 0) {
                    queue.Enqueue(new int[]{steps + 1, x2, y2});

                    // Set the added cell to a 1 so we don't traverse over it again.
                    grid[x2][y2] = 1;
                }
            }
        }
        
        // If the queue is empty and we haven't found the exit (bottom-right cell), return -1.
        return -1;
    }
}