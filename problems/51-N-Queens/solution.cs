public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        // Set up the result list, our return value.
        IList<IList<string>> result = new List<IList<string>>();

        // Set up three HashSets to keep track of which columns and diagonals are occupied.
        // Rows will be what our backtracking is running on, so we do not need to keep track of it.
        HashSet<int> columns = new HashSet<int>();
        HashSet<int> positiveDiag = new HashSet<int>();
        HashSet<int> negativeDiag = new HashSet<int>();

        // The current board
        char[][] board = new char[n][];
        
        // Pre-fill the board with empty spaces, represented by '.'
        for(int i=0; i<n; i++) { // O(n)
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }
        
        // The backtracking function.
        void SolveNQueens(int rowNum) { // O(n^2)
            // If we've reached the end of the board, we've found a solution.
            if(rowNum == n) {
                // The board is not a list of strings, but a list of char arrays.
                // We need to convert it to a list of strings, as that is the return type.
                IList<string> resultItem = new List<string>();
                
                // Loop through the board, adding each row to the temporary resultItem list.
                foreach(char[] row in board) {
                    resultItem.Add(new string(row));
                }
                
                // Add the resultItem to the result list.
                result.Add(resultItem);
            }
            
            // Otherwise, we need to try each possible position for this row.
            for(int colNum=0; colNum<n; colNum++) {
                // If this position is not occupied, we can use it.
                // We need to check if another queen is occupying this column, the
                // positive diagonal, or the negative diagonal this square is on.
                if(columns.Contains(colNum) || positiveDiag.Contains(rowNum + colNum) || negativeDiag.Contains(rowNum - colNum)) { // O(1)
                    // This position is occupied, so we can't use it.
                    continue;
                } else {
                    // This position is not occupied, so we can use it. We need to mark it as occupied.

                    // Add this position to the columns, positive diagonal, and negative diagonal.
                    columns.Add(colNum);
                    positiveDiag.Add(rowNum + colNum);
                    negativeDiag.Add(rowNum - colNum);

                    // Add a queen to the board at this position.
                    board[rowNum][colNum] = 'Q';
                    
                    // Recurse on the next row.
                    SolveNQueens(rowNum + 1);
                    
                    // If we get here, we've backtracked. We need to remove the queen from this position, 
                    // which means we need to mark the column, positive diagonal, and negative diagonal as free.

                    // Remove this position from the columns, positive diagonal, and negative diagonal.
                    columns.Remove(colNum);
                    positiveDiag.Remove(rowNum + colNum);
                    negativeDiag.Remove(rowNum - colNum);

                    // Remove the queen from the board at this position.
                    board[rowNum][colNum] = '.';
                }
            }
        }
        
        // Start the backtracking process at row 0.
        SolveNQueens(0);

        // Return the result.
        return result;
    }
}