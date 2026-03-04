public class Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] rowSum = new int[m];
        int[] colSum = new int[n];

        // Step 1: Compute row sums and column sums
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1) {
                    rowSum[i]++;
                    colSum[j]++;
                }
            }
        }
        int count = 0;

        // Step 2: Check the invariant for each cell
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && rowSum[i] == 1 && colSum[j] == 1) {
                    count++;
                }
            }
        }

        return count;
    }
}
