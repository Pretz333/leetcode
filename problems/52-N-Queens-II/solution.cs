public class Solution {
    public int TotalNQueens(int n) {
        // This is literally the same as the N-Queens problem (#51), except we don't need to manage the board 
        // and we're outputting an int. I've simply removed all of the board management code, changed the 
        // result to be an int, and am incrementing the result instead of adding the board to the result.
        
        // This is now an int
        int result = 0;
        HashSet<int> columns = new HashSet<int>();
        HashSet<int> positiveDiag = new HashSet<int>();
        HashSet<int> negativeDiag = new HashSet<int>();

        // We no longer need the board management code, so it's been removed.
        
        void SolveNQueens(int rowNum) {
            if(rowNum == n) {
                // This is now an int, so we increment it instead of adding the board to the result
                result++;
            }
            
            for(int colNum=0; colNum<n; colNum++) {
                if(!columns.Contains(colNum) && !positiveDiag.Contains(rowNum + colNum) && !negativeDiag.Contains(rowNum - colNum)) {
                    columns.Add(colNum);
                    positiveDiag.Add(rowNum + colNum);
                    negativeDiag.Add(rowNum - colNum);

                    // We don't need to add a Queen to the board
                    
                    SolveNQueens(rowNum + 1);
                    
                    columns.Remove(colNum);
                    positiveDiag.Remove(rowNum + colNum);
                    negativeDiag.Remove(rowNum - colNum);

                    // We don't need to remove a Queen from the board
                }
            }
        }
        
        SolveNQueens(0);

        return result;
    }
}