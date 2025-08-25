public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        int n = mat.Length;
        if (n == 0) return System.Array.Empty<int>();
        int m = mat[0].Length;
        if (m == 0) return System.Array.Empty<int>();
        if (n == 1) return mat[0];

        var ans = new int[n * m];

        int i = 0, j = 0, k = 0;
        if (m == 1) {
            foreach (var x in mat) ans[k++] = x[0];
            return ans;
        }

        bool goDown = false;

        while (k < n * m) {
            ans[k++] = mat[i][j];

            if (k == n * m) break;

            if (!goDown) {
                if (j == m - 1) {
                    i++;
                    goDown = true;
                } else if (i == 0) {
                    j++;
                    goDown = true;
                } else {
                    i--; j++;
                }
            } else {
                if (i == n - 1) {
                    j++;
                    goDown = false;
                } else if (j == 0) {
                    i++;
                    goDown = false;
                } else {
                    i++; j--;
                }
            }
        }
        return ans;
    }
}