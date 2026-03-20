public class Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] ans = new int[m - k + 1][];
        for (int i = 0; i <= m - k; i++) {
            ans[i] = new int[n - k + 1];
            for (int j = 0; j <= n - k; j++) {
                HashSet<int> values = new HashSet<int>();
                for (int x = 0; x < k; x++) {
                    for (int y = 0; y < k; y++) {
                        values.Add(grid[i + x][j + y]);
                    }
                }
                if (values.Count <= 1) {
                    ans[i][j] = 0;
                } else {
                    List<int> sortedValues = values.ToList();
                    sortedValues.Sort();
                    int minDiff = int.MaxValue;
                    for (int t = 1; t < sortedValues.Count; t++) {
                        minDiff = Math.Min(minDiff, sortedValues[t] - sortedValues[t - 1]);
                    }
                    ans[i][j] = minDiff;
                }
            }
        }
        return ans;
    }
}
