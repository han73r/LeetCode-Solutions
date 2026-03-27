public class Solution {
    public bool AreSimilar(int[][] mat, int k) {
        int rows = mat.Length;
        int cols = mat[0].Length;
        k = k % cols;
        if (k == 0) return true;
        for (int i = 0; i < rows; i++) {
            if (!IsRowSimilar(mat[i], k, cols, i % 2 == 0)) {
                return false;
            }
        }
        return true;
    }

    private static bool IsRowSimilar(int[] row, int k, int cols, bool isEvenRow) {
        int shift = isEvenRow ? k : (cols - k) % cols;
        for (int j = 0; j < cols; j++) {
            int shiftedIndex = (j + shift) % cols;
            if (row[j] != row[shiftedIndex]) {
                return false;
            }
        }
        return true;
    }
}
