public class Solution {
    public int[][] Transpose(int[][] matrix) {
        // Create a new array to store the transposed matrix.
        int[][] transposed = new int[matrix[0].Length][];

        // For each row in the matrix, make a new array to store the row.
        for (int i = 0; i < matrix[0].Length; i++) { // O(number of rows) = O(n)
            transposed[i] = new int[matrix.Length];
        }

        // For each row in the matrix
        for (int i = 0; i < matrix.Length; i++) { // O(number of rows) = O(n)
            // For each spot in the row
            for (int j = 0; j < matrix[0].Length; j++) { // O(number of columns) = O(n)
                // Store the value in its transposed
                // position in the transposed array.
                transposed[j][i] = matrix[i][j];
            }
        }
        
        return transposed;

        // Total time complexity is O(number of rows + number of rows* number of columns), 
        // which is equal to O(n + n^2), which simplifies to O(n^2) (from my understanding).
        // You also view it O(n^2) from the outset as we have two nested loops.
    }
}